using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodUI : MonoBehaviour
{
    public string name;
    public string description;

    private void Start()
    {
        gameObject.AddComponent<DisplayInfoOnHover>().text = name + "\n\n\"" + description + "\"";
    }
}
