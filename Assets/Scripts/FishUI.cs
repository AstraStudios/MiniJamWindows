using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FishUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string name;

    public void OnPointerEnter(PointerEventData e)
    {
        FishInfoPopup.Instance.gameObject.SetActive(true);
        FishInfoPopup.Instance.info_text.text = name+"\n$15\n\n\"Get me in a tank!\"";
    }

    public void OnPointerExit(PointerEventData e)
    {
        FishInfoPopup.Instance.gameObject.SetActive(false);
    }
}
