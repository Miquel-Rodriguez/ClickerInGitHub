using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graphic : Component
{
    [SerializeField] private float baseBitesPerSecond;
    public float bitesForSeocnd;
    [SerializeField] private float bitesPerSecondMultiplier;


    private void Start()
    {
        SetStats();
        SetDescription();
    }

    private void SetStats()
    {
        bitesForSeocnd = baseBitesPerSecond;
    }

    public void LevelUP()
    {
        lvl++;


        if ((lvl / 5) % 0 == 0)
        {
            bitesPerSecondMultiplier *= 2;
        }
        else
        {
            bitesPerSecondMultiplier *= 1.1f;
        }


        cost = cost * (cost / 2);

        bitesForSeocnd += bitesPerSecondMultiplier;

        SetDescription();
    }



    public void SetDescription()
    {
        statsDescription = "Bites Per Second: " + bitesForSeocnd;
    }
}
