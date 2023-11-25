using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish
{
    //fish go in this class

    public string Name;
    public double minWeight;
    public double maxWeight;
    public int fightPower;
    public Sprite fishSprite;

    public Fish(string name_, double minWeight_, double maxWeight_, int fightPower_, Sprite fishSprite_)
    {
        Name = name_;
        minWeight = minWeight_;
        maxWeight = maxWeight_;
        fightPower = fightPower_;
        fishSprite = fishSprite_;
    }
}
