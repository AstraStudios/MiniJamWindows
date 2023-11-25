using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DisplayInfoOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // ONLY USE THIS VARIABLE
    [TextArea(15,20)] public string text;

    private my_text_item item;

    private void Awake()
    {
        item = new my_text_item(text);
    }

    private void Update() { item.text = text; }

    public void OnPointerEnter(PointerEventData e)
    {
        FishInfoPopup.Instance.text_queue.Add(item);
    }

    public void OnPointerExit(PointerEventData e)
    {
        FishInfoPopup.Instance.text_queue.Remove(item);
    }
}
