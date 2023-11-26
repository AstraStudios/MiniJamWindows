using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class printonhover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData e)
    {
        print("enter");
    }

    public void OnPointerExit(PointerEventData e)
    {
        print("exit");
    }
}
