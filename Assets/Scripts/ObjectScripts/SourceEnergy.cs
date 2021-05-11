using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceEnergy : Component
{
    public float maxEnergy;
    public float energyForSecond;
    public float energyCostForClick;

    private void Start()
    {
        statsDescription = "Max Energy Capacity: "+maxEnergy+"\n" +
            "Energy recover: "+energyForSecond+"\n"+
            "Cost per Click: "+energyCostForClick;
    }




}
