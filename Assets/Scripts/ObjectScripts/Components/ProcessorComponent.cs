using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessorComponent : Component
{

    public float bitesPerClick;
    public float energyPerClick;

    private void Start()
    {
        statsDescription = "bites per click: "+ bitesPerClick+"\n" +
            "cost for click: "+energyPerClick;
    }
}
