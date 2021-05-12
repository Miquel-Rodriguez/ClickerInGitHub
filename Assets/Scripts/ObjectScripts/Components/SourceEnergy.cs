using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceEnergy : Component
{
    public float maxEnergy;
    public float energyForSecond;
    [SerializeField] EnergyBar energyBar;

    private void Start()
    {
        SetDescription();
    }

    public void SetMaxEnergy(float newMaxEnergy)
    {
        maxEnergy = newMaxEnergy;
        energyBar.ChangeMaxEnergy(maxEnergy);
    }

    public void LevelUP()
    {
        lvl++;
        SetDescription();
    }

    public void SetDescription()
    {
        statsDescription = "Max Energy Capacity: " + maxEnergy + "\n" +
           "Energy recover: " + energyForSecond;
    }
}
