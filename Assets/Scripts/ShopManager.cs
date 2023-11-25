using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviourSingleton<ShopManager>
{
    [SerializeField] List<GameObject> high_shelf_prefabs;
    [SerializeField] List<GameObject> low_shelf_prefabs;

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

        return _list;
    }

    public void LoadItems()
    {
        // load items onto high shelf
        List<GameObject> shuffled = Shuffle(high_shelf_prefabs);
        for (int index=0; index<3; index++)
        {
            Transform item = Instantiate(shuffled[Random.Range(0, shuffled.Count)]).transform;
            item.position = high_shelf_item_spawner.position + Vector3.right * (60f * (float)index);
            item.SetParent(high_shelf);
        }

        // load items onto low shelf
        shuffled = Shuffle(low_shelf_prefabs);
        for (int index=0; index<2; index++)
        {
            Transform item = Instantiate(shuffled[Random.Range(0, shuffled.Count)]).transform;
            item.position = low_shelf_item_spawner.position + Vector3.right * (60f * (float)index);
            item.SetParent(low_shelf);
        }
    }
}
