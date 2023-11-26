using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishUI : MonoBehaviour
{
    public string name;
    public float weight;

    private void Start()
    {
        gameObject.AddComponent<DisplayInfoOnHover>().text = name + "\n\n\"Get me in a tank!\"";
    }
}
