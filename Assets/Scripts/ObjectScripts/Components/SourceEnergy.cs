using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceEnergy : Component
{
    public float maxEnergy;
    public float energyForSecond;

    private void Start()
    {
        statsDescription = "Max Energy Capacity: " + maxEnergy + "\n" +
            "Energy recover: " + energyForSecond;
    }




}
