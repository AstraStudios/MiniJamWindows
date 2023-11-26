using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishTank : MonoBehaviour
{
    [SerializeField] bool sell_tank = false;

    public List<FishUI> fishies;
    public int capacity;

    private DisplayInfoOnHover hover_text;

    public void Awake()
    {
        fishies = new List<FishUI>();
        hover_text = gameObject.AddComponent<DisplayInfoOnHover>();
    }

    // random number from a seed
    private float hash(float p)
    {
        p = (p * 0.011f) % 1f; 
        p *= p + 7.5f; 
        p *= p + p;
        return p % 1f;
    }

    private void Update()
    {
        Rect tank_size = gameObject.GetComponent<RectTransform>().rect;

        float index = 1;
        foreach (FishUI fish in fishies)
        {
            Rect fish_size = fish.GetComponent<RectTransform>().rect;
            SpriteRenderer fishRenderer = fish.gameObject.GetComponent<SpriteRenderer>();

            fish.gameObject.transform.position = new Vector3(
                transform.position.x + Mathf.Sin(Time.time * index) * ((tank_size.width - fish_size.width) / 2f),
                fish.transform.position.y,
                fish.transform.position.z
            ) ;
            index++;
        }

        if (sell_tank)
        {
            hover_text.text = "Click me to sell your fish.\n\n\"Uh oh...\" - fish";
            return;
        }

        if (InventoryManager.Instance.current_fish)
            hover_text.text = "Click me to store your fish.\n\n\"I'm home!\" - fish";
        else
            hover_text.text = "Click me to take a fish.\n\n\"NOOOO!!!\" - fish";
    }

    // called when clicked
    public void move_fish()
    {

        // put fish in tank
        if (InventoryManager.Instance.current_fish)
        {
            FishUI fish = InventoryManager.Instance.current_fish;
            InventoryManager.Instance.current_fish = null;

            fishies.Add(fish);

            Rect tank_size = gameObject.GetComponent<RectTransform>().rect;
            Rect fish_size = fish.GetComponent<RectTransform>().rect;

            fish.transform.SetParent(transform);
            fish.transform.position = transform.position + Vector3.up * (hash(Time.time*1000f) - .5f) * (tank_size.height - fish_size.height);

            // if this is the shop's tank
            if (sell_tank)
            {
                // calculate price
                float price = 10f;
                if (fish.name == "john")
                    price = 15f;

                InventoryManager.Instance.money += price;
            }
        }

        // take fish out of tank
        // TODO: move this to the fishui script so you can click specific fish
        else if (fishies.Count > 0)
        {
            if (sell_tank) return;

            FishUI fish = fishies[0];
            InventoryManager.Instance.current_fish = fish;

            fishies.RemoveAt(0);
        }
    }
}
