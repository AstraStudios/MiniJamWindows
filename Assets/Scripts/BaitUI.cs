using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitUI : MonoBehaviour
{
    public string name;

    private void Start()
    {
        gameObject.AddComponent<DisplayInfoOnHover>().text = name + "\n\n" + "\"Im hungry for fish! Or are the fish hungry for me?\"";
    }
}
