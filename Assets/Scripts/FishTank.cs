using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishUITank : MonoBehaviour
{
    public List<FishUI> fishies;
    public int capacity;

    public void Awake()
    {
        fishies = new List<FishUI>();
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
            fish.gameObject.transform.position = transform.position + 
                Vector3.right * Mathf.Sin(Time.time * index) * (tank_size.width / 2f - 50f) + 
                Vector3.up    * (hash(index+.1f) - .5f)          * (tank_size.height - 50f);
            index++;
        }
    }

    public void addFish()
    {
        if (InventoryManager.Instance.current_fish)
        {
            FishUI fish = InventoryManager.Instance.current_fish;
            InventoryManager.Instance.current_fish = null;

            fishies.Add(fish);

            fish.transform.parent = transform;
        }
    }
}
