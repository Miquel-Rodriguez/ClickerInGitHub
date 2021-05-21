using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceEnergy : Component
{

    [SerializeField] private float baseSaveEnergy;
    public float saveEnergy;
    [SerializeField] private float increment;

    public float maxEnergy=200;

    [SerializeField] EnergyBar energyBar;

    private void Start()
    {
        SetStats();
        SetDescription();
        energyBar.SetRealEnergyCost();
    }

    private void SetStats()
    {
        saveEnergy = baseSaveEnergy;
    }

    public void LevelUP()
    {
        lvl++;

        if ((lvl / 5) % 0 == 0)
        {
            increment *= 2;
        }

        cost = cost * (cost / 2);

        saveEnergy += increment;
        energyBar.SetRealEnergyCost();

        SetDescription();
    }

    public void SetDescription()
    {
        statsDescription = "save energy per click: " + saveEnergy;
    }
}
