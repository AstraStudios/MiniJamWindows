using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

struct Window {
    public Window(string name, string description_) {
        sceneName = name;
        description = description_;
        timer = 0;
    }

    public string sceneName;
    public string description;
    public float timer;
}

public class UIManager : MonoBehaviourSingletonPersistent<UIManager>
{
    ////// FIELDS

    [SerializeField] float time_to_open;

    [SerializeField] Transform shutters;
    [SerializeField] Transform shutter_closed;
    [SerializeField] Transform shutter_opened;

    [SerializeField] TMP_Text description;

    ////// PRIVATE MEMBERS

    List<Window> windows;
    uint active_window_index = 0;

    ////// STATE ):

    // TODO: convert to an enum
    bool closing_shutters = false;
    bool opening_shutters = false;
    float changing_sutters_start = 0; // time

    private void Awake()
    {
        base.Awake();

        windows = new List<Window>();
        windows.Add(new Window(
            SceneManager.GetActiveScene().name,
@"Silly Lake

The best lake in the Northeast!

- Tons of Cod
- A bit of Carp"
       ));

        windows.Add(new Window("sethtesting2",
@"Evil Lake ):<

The WORST lake in the Northeast!

- NO fish
- maybe SOME junk"
        ));
    }

    private void Start()
    {
        description.text = windows[(int)active_window_index].description;
    }

    private void Update()
    {
        // since how open the shutters are is dependent on the difference from the time,
        // if it is the same it is forced to one of the positions
        if (!(closing_shutters || opening_shutters))
            changing_sutters_start = Time.time;

        // move shutters from opened to closed
        shutters.position = Vector3.Lerp(
            shutter_opened.position,
            shutter_closed.position,
            (opening_shutters? // invert if opening
                 1 - (Time.time - changing_sutters_start) / time_to_open :
                 (Time.time - changing_sutters_start) / time_to_open
            ));

        // if we just finished closing
        // LOADS NEW SCENE
        if (Time.time - changing_sutters_start >= 1.0 && closing_shutters)
        {
            shutters.position = shutter_closed.position;

            // start opening
            changing_sutters_start = Time.time;
            opening_shutters = true;
            closing_shutters = false;

            // load scene
            SceneManager.LoadScene(windows[(int)active_window_index].sceneName);
            description.text = windows[(int)active_window_index].description;
        }
        // if we just finished opening
        if (Time.time - changing_sutters_start >= 1.0 && opening_shutters)
        {
            shutters.position = shutter_opened.position;

            opening_shutters = false;
        }
    }

    void loadWindow(uint index)
    {
        active_window_index = index;

        // start opening
        changing_sutters_start = Time.time;
        closing_shutters = true;
    }

    // TODO: add limits
    public void NextScene()     { loadWindow(active_window_index + 1); }
    public void PreviousScene() { loadWindow(active_window_index - 1); }
}
