using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviourSingletonPersistent<InventoryManager>
{
    [SerializeField] Transform fish_display_box;
    [SerializeField] Transform rod_display_box;
    [SerializeField] Transform bait_display_box;

    [SerializeField] TMP_Text coin_text;

    [SerializeField] GameObject dummy_fish_prefab; // delete me later

    public float money;

    [HideInInspector] public FishUI current_fish;
    [HideInInspector] public RodUI current_rod;
    [HideInInspector] public BaitUI current_bait;

    private void Start()
    {
        current_fish = Instantiate(dummy_fish_prefab).GetComponent<FishUI>();
    }

    private void Update()
    {
        if (current_fish != null)
        {
            current_fish.transform.SetParent(fish_display_box);
            current_fish.transform.position = fish_display_box.position;
        }
        if (current_bait != null)
        {
            current_bait.transform.SetParent(bait_display_box);
            current_bait.transform.position = bait_display_box.position;
        }
        if (current_rod != null)
        {
            current_rod.transform.SetParent(rod_display_box);
            current_rod.transform.position = rod_display_box.position;
        }

        coin_text.text = money.ToString();
    }
}
