using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

class UIItem
{
    RodUI rod;
    BaitUI bait;
    FishUI fish;

    public bool isFish() { return fish != null; }
    public bool isBait() { return bait != null; }
    public bool isRod() { return rod != null; }

    UIItem(RodUI rod_) { rod = rod_; }
    UIItem(BaitUI bait_) { bait = bait_; }
    UIItem(FishUI fish_) { fish = fish_; }
}

public class StoreItem : MonoBehaviour
{
    // untested: if you want assign multiple of these and sell a combo
    [SerializeField] public RodUI rod;
    [SerializeField] public BaitUI bait;
    [SerializeField] public FishUI fish;

    [SerializeField] public float price = 10f;
    [SerializeField] TMP_Text price_text_box;

    public bool isFish() { return fish != null; }
    public bool isBait() { return bait != null; }
    public bool isRod() { return rod != null; }

    private void Awake()
    {
        price_text_box.text = price.ToString() + "c";
    }

    public void Sell()
    {
        if (InventoryManager.Instance.money < price) return;

        price_text_box.text = "SOLD";

        InventoryManager.Instance.money -= price;

        // move into inventory
        if (isFish()) { InventoryManager.Instance.current_fish = fish; }
        if (isBait()) { InventoryManager.Instance.current_bait = bait; }
        if (isRod()) { InventoryManager.Instance.current_rod = rod; }
    }
}
