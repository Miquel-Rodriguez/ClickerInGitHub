using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : Component
{
    [SerializeField] private float baseMaxBitesCapacity;
    public float maxBitesCapacity;
    [SerializeField] private float multiplier;

    private void Awake()
    {
      //  PlayerPrefs.DeleteAll();
    }

    private void Start()
    {
        SetStats();
        SetDescription();

        int olvl = PlayerPrefs.GetInt("LVLStorage",1);

        if(olvl != 1)
        {
            for (int i = 1; i < olvl; i++)
            {
                LevelUP();
            }
        }
       

    }

    public void SaveLvl()
    {
        PlayerPrefs.SetInt("LVLStorage", lvl);
    }

    private void SetStats()
    {
        maxBitesCapacity = baseMaxBitesCapacity;
        cost = basecost;
    }

    public void LevelUP()
    {
        lvl++;


        if (lvl % 5 == 0)
        {
            multiplier *= 2;
  
        }
        else
        {
            multiplier *=1.1f;
        }


        cost = cost * (cost / 2);

        maxBitesCapacity += multiplier;


        SetDescription();
        SaveLvl();
    }

    public void SetDescription()
    {
        statsDescription = "Max bites capacity: " + maxBitesCapacity;
    }
}
