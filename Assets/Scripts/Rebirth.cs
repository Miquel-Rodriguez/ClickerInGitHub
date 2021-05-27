using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebirth : MonoBehaviour
{
    [SerializeField] NumberController bits;
    [SerializeField] Graphic lvlGraphic;
    [SerializeField] ProcessorComponent lvlProcessor;
    [SerializeField] Storage lvlStorage;
    [SerializeField] SourceEnergy lvlEnergy;
    [SerializeField] EnergyBar energyBar;

    

    public void resetAll()
    {
        if(bits.currentBits < 10000)
        {
            //0 moneda de rebirth
        }
        if(bits.currentBits > 10000 && bits.currentBits< 100000)
        {
            // 10 monedas de rebirth
        }
        if (bits.currentBits > 100000 && bits.currentBits < 1000000)
        {
            // 100 monedas de rebirth
        }
        if (bits.currentBits > 1000000 && bits.currentBits < 10000000)
        {
            // 1000 monedas de rebirth
        }
        if (bits.currentBits > 10000000 && bits.currentBits < 100000000)
        {
            // 10000 monedas de rebirth
        }
        if (bits.currentBits > 100000000 && bits.currentBits < 1000000000)
        {
            // 100000 monedas de rebirth
        }
        if (bits.currentBits > 1000000000 && bits.currentBits < 10000000000)
        {
            // 1000000 monedas de rebirth
        }
        if (bits.currentBits > 10000000000 && bits.currentBits < 100000000000)
        {
            // 1000000 monedas de rebirth
        }
        energyBar.currentEnergy = lvlEnergy.maxEnergy;
        energyBar.SetMaxHealth(lvlEnergy.maxEnergy);
        //  energyBar.SetHealth(lvlEnergy.maxEnergy);

        bits.currentBits = 0;
        lvlGraphic.lvl = 1;
        lvlGraphic.SetStats();
        lvlGraphic.SaveLvl();

        lvlEnergy.lvl = 1;
        lvlEnergy.SetStats();
        lvlEnergy.SaveLvl();

        lvlProcessor.lvl = 1;
        lvlProcessor.SetStats();
        lvlProcessor.SaveLvl();

        lvlStorage.lvl = 1;
        lvlStorage.SetStats();
        lvlStorage.SaveLvl();

       
    }
}
