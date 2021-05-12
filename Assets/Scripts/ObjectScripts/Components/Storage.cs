using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : Component
{
    public float maxBitesCapacity;

    private void Start()
    {
        SetDescription();
    }

    public void LevelUP()
    {
        lvl++;
        SetDescription();
    }

    public void SetDescription()
    {
        statsDescription = "Max bites capacity: " + maxBitesCapacity;
    }
}
