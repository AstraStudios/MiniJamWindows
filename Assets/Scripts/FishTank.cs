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

    private void Update()
    {
        foreach (FishUI fish in fishies)
        {
            fish.gameObject.transform.position = transform.position + new Vector3(Random.value-.5f, Random.value-.5f, Random.value-.5f) * 40;
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
