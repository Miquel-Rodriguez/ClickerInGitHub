using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graphic : Component
{
    public float bitesForSeocnd;

    private void Start()
    {
        statsDescription = "Bites Per Second: " + bitesForSeocnd;
    }
}
