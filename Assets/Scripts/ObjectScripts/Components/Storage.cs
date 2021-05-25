using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : Component
{
    [SerializeField] private float baseMaxBitesCapacity;
    public float maxBitesCapacity;
    [SerializeField] private float multiplier;

    private void Start()
    {
        SetStats();
        SetDescription();
    }

    public void SetStats()
    {
        maxBitesCapacity = baseMaxBitesCapacity;
    }

    public void LevelUP()
    {
        lvl++;


        if (lvl % 5 == 0)
        {
            multiplier *= 2;
  
        }
        else
        {
            multiplier *=1.1f;
        }


        cost = cost * (cost / 2);

        maxBitesCapacity += multiplier;


        SetDescription();
    }

    public void SetDescription()
    {
        statsDescription = "Max bites capacity: " + maxBitesCapacity;
    }
}
