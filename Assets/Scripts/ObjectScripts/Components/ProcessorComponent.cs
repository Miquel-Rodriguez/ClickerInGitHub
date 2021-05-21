using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessorComponent : Component
{


    [SerializeField] private float baseBitesPerClick;
    public float bitesPerClick;

    [SerializeField] private float baseEnergyPerClick;
    public float energyPerClick;

    [SerializeField] private float bitesMultiplier;
    [SerializeField] private float energyMultiplier;

    private void Start()
    {
        SetStats();
        SetDescription();
    }

    private void SetStats()
    {
        bitesPerClick = baseBitesPerClick;
        energyPerClick = baseEnergyPerClick;
    }

    public void LevelUP()
    {
        lvl++;

        if (lvl % 5 == 0)
        {
            energyMultiplier *=2;
            bitesMultiplier *=2;
        }
        else
        {
            bitesMultiplier *= 1.1f;
            energyMultiplier *= 1.1f;
        }


        cost = cost * (cost / 2);

        bitesPerClick += bitesMultiplier;
        energyPerClick += energyMultiplier;

        SetDescription();
    }

    public void SetDescription()
    {
        statsDescription = "bites per click: " + bitesPerClick + "\n" +
              "cost for click: " + energyPerClick;
    }
}
