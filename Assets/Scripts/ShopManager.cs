using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviourSingleton<ShopManager>
{
    [SerializeField] FishTank sell_tank;

    [SerializeField] List<GameObject> item_prefabs;
    [SerializeField] Transform item_parent;

    [SerializeField] Transform high_shelf;
    [SerializeField] Transform low_shelf;

    [SerializeField] Transform high_shelf_item_spawner;
    [SerializeField] Transform low_shelf_item_spawner;

    private void Start()
    {
        LoadItems();
    }

    public static List<T> Shuffle<T>(List<T> _list)
    {
        List<T> list = new List<T>(_list);
        for (int i = 0; i < list.Count; i++)
        {
            T temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }

        return list;
    }

    public void LoadItems()
    {
        // delete all items
        for (int i = 0; i < item_parent.childCount; i++)
            Destroy(item_parent.GetChild(i).gameObject);

        // clear tank
        sell_tank.fishies = new List<FishUI>();

        // load items onto high shelf
        List<GameObject> shuffled = Shuffle(item_prefabs);
        for (int index=0; index<3; index++)
        {
            Transform item = Instantiate(shuffled[index]).transform;
            item.position = high_shelf_item_spawner.position + Vector3.right * (60f * (float)index);
            item.SetParent(item_parent);
        }

        // load items onto low shelf
        for (int index=3; index<4; index++)
        {
            Transform item = Instantiate(shuffled[index]).transform;
            item.position = low_shelf_item_spawner.position + Vector3.right * (60f * ((float)index-3f));
            item.SetParent(item_parent);
        }
    }
}
