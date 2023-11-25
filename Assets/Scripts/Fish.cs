using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    //fish go in this class

    public string Name { get; set; }
    public double minWeight { get; set; }
    public double maxWeight { get; set; }
    public int fightPower { get; set; }
    public Sprite fishSprite { get; set; }
}
