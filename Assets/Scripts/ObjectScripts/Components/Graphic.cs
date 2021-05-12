using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graphic : Component
{
    public float bitesForSeocnd;

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
        statsDescription = "Bites Per Second: " + bitesForSeocnd;
    }
}
