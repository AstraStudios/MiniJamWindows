using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


class Window {
    public string scene_name;
    public string description;
    public float timer;
    public bool open = true;
    public float price;

    public Window(string name, bool open_, float price_, float timer_, string description_) {
        scene_name = name;
        description = description_;
        timer = timer_;

        price = price_;
        open = open_;
    }

    // true if should close
    public bool tick()
    {
        if (!open) return false;

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            open = false;
            timer = 0f;
            return true;
        }
        return false;
    }
}

public class UIManager : MonoBehaviourSingletonPersistent<UIManager>
{
    ////// FIELDS

    //[SerializeField] float time_to_open;

    [SerializeField] GameObject shopUI;

    [SerializeField] Transform shutters;
    [SerializeField] Transform shutter_closed;
    [SerializeField] Transform shutter_opened;

    [SerializeField] GameObject buy_button;
    [SerializeField] TMP_Text buy_button_text;

    [SerializeField] TMP_Text description;
    [SerializeField] TMP_Text timer_text;

    ////// PRIVATE MEMBERS

    List<Window> windows;
    int active_window_index = 0;

    ////// STATE ):

    // TODO: convert to an enum
    enum WindowState
    {
        Closing,
        Opening,
        Open,
        Closed,
    }
    WindowState window_state = WindowState.Open; 
    float opening_shutters_percent = 1f;

    private void Awake()
    {
        base.Awake();

        windows = new List<Window>();
        windows.Add(new Window(
            "shop", true, 0f, 45f,
@"The Shop

Sell your fish and buy new gear!"
       ));

        windows.Add(new Window(
            "sethtesting", false, 10f, 0f,
@"Silly Lake

The best lake in the Northeast!

- Tons of Cod
- A bit of Carp"
       ));

        windows.Add(new Window(
            "sethtesting2", true, 15f, 30f,
@"Evil Lake ):<

The WORST lake in the Northeast!

- NO fish
- maybe SOME junk"
        ));
    }

    private void Start()
    {
        description.text = windows[active_window_index].description;
    }

    private void Update()
    {
        int i = 0;
        foreach (Window window in windows)
        {
            bool close = window.tick();
            if (close && window == windows[active_window_index])
                window_state = WindowState.Closing;

            // change the shop if not active
            if (close && i == 0 && active_window_index != i)
            {
                ShopManager.Instance.LoadItems();
                window.open = true;
                window.timer = 20f;
            }

            i++;
        }

        Window active_window = windows[active_window_index];

        timer_text.text = 
            Mathf.FloorToInt(active_window.timer / 60f).ToString() + 
            ":" +
            Mathf.RoundToInt(active_window.timer % 60f).ToString("D2");

        // since how open the shutters are is dependent on the difference from the time,
        // if it is the same it is forced to one of the positions
        if (window_state == WindowState.Opening)
             opening_shutters_percent += Time.deltaTime;
        if (window_state == WindowState.Closing)
             opening_shutters_percent -= Time.deltaTime;


        // done closing
        // LOADS NEW SCENE
        if (opening_shutters_percent <= 0.0 && window_state == WindowState.Closing)
        {
            shutters.position = shutter_closed.position;

            window_state = WindowState.Closed;

            // load scene
            SceneManager.LoadScene(active_window.scene_name);
            description.text = active_window.description;

            // open new scene
            if (active_window.open)
            {
                window_state = WindowState.Opening;
            }
            // if the window is the shop, activate it
            if (active_window_index == 0)
            {
                window_state = WindowState.Opening;
                shopUI.SetActive(true);

                if (!active_window.open)
                {
                    ShopManager.Instance.LoadItems();
                    active_window.open = true;
                    active_window.timer = 20f;
                }
            }
            else shopUI.SetActive(false);

            // lock window
            opening_shutters_percent = 0.0f;
        }

        // done opening
        if (opening_shutters_percent >= 1.0 && window_state == WindowState.Opening)
        {
            window_state = WindowState.Open;

            opening_shutters_percent = 1.0f;
        }

        // display buy area
        if (!active_window.open)
        {
            buy_button.SetActive(true);
            if (active_window_index == 0) // shop
                buy_button_text.text = "Going to a new shop...";
            else
                buy_button_text.text = "Buy " + active_window.scene_name + " for 15 seconds\n" + active_window.price + "c";
        }
        else if (window_state == WindowState.Open) // only disable after the button is hidden
            buy_button.SetActive(false);

        // move shutters from closed to open
        shutters.position = Vector3.Lerp(
            shutter_closed.position,
            shutter_opened.position,
            opening_shutters_percent);
    }

    public void buy_active_window()
    {
        Window active_window = windows[active_window_index];

        if (active_window.open) return;
        if (InventoryManager.Instance.money < active_window.price) return;

        InventoryManager.Instance.money -= active_window.price;

        active_window.open = true;
        active_window.timer = 15f;
        window_state = WindowState.Opening;
    }

    void loadWindow(int index)
    {
        if (index < 0) return;
        if (index >= windows.Count) return;

        //if (!(window_state == WindowState.Open || window_state == WindowState.Closed)) return;

        active_window_index = index;
        window_state = WindowState.Closing; 
    }

    // TODO: add limits
    public void NextScene()     { loadWindow(active_window_index + 1); }
    public void PreviousScene() { loadWindow(active_window_index - 1); }
}
