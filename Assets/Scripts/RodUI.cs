using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodUI : MonoBehaviour
{
    public string _name;
    public string _fightPower;

    private void Start()
    {
        gameObject.AddComponent<DisplayInfoOnHover>().text = _name + "\n\n\"" + _fightPower + "\"";
    }
}
