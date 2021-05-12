using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessorComponent : Component
{

    public float bitesPerClick;
    public float energyPerClick;

    private void Start()
    {
        SetDescription();
    }

    public void LevelUP()
    {
        SetDescription();
    }

    public void SetDescription()
    {
        statsDescription = "bites per click: " + bitesPerClick + "\n" +
              "cost for click: " + energyPerClick;
    }
}
