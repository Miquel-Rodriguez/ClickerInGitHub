using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : Component
{
    public float maxBitesCapacity;

    private void Start()
    {
        statsDescription = "Max bites capacity: " + maxBitesCapacity;
    }
}
