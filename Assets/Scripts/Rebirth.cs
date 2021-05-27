using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rebirth : MonoBehaviour
{
    [SerializeField] NumberController bits;
    [SerializeField] Graphic lvlGraphic;
    [SerializeField] ProcessorComponent lvlProcessor;
    [SerializeField] Storage lvlStorage;
    [SerializeField] SourceEnergy lvlEnergy;
    [SerializeField] EnergyBar energyBar;
    public int numRebirths;
    [SerializeField] TextMeshProUGUI textRebirth;
    [SerializeField] TextMeshProUGUI textMoneyRebirth;
    private string normalRebirth = "0% enhanced components";
    int rebirthMoneyText;
    string firstTextMoney = "You will lose all your bits and your components stats will be 0, but you will gain ";
    string secondTextMoney = " coins that you can exchange for a ticket of the pasive gacha (20 coins = 1 ticket)";


    private void Update()
    {
        /* if (se hace el gacha de rebirth)
           {
             numRebirths++;
             textRebirth.text = numRebirths * 7 + normalRebirth;
             lvlGraphic.baseBitesPerSecond += lvlGraphic.baseBitesPerSecond * 0.7f;
             lvlGraphic.bitesForSeocnd += lvlGraphic.bitesForSeocnd * 0.7f;

           }
        */
        textMoneyRebirth.text = firstTextMoney + rebirthMoneyText + secondTextMoney;
    }

    public void resetAll()
    {
        if(bits.currentBits < 10000)
        {
            //0 moneda de rebirth
        }
        if(bits.currentBits > 10000 && bits.currentBits< 100000)
        {
            bits.numPasiveMoney+=2;
            rebirthMoneyText = 2;
        }
        if (bits.currentBits > 100000 && bits.currentBits < 1000000)
        {
            bits.numPasiveMoney+=4;
            rebirthMoneyText = 4;
        }
        if (bits.currentBits > 1000000 && bits.currentBits < 10000000)
        {
            bits.numPasiveMoney += 6;
            rebirthMoneyText = 6;
        }
        if (bits.currentBits > 10000000 && bits.currentBits < 100000000)
        {
            bits.numPasiveMoney += 8;
            rebirthMoneyText = 8;
        }
        if (bits.currentBits > 100000000 && bits.currentBits < 1000000000)
        {
            bits.numPasiveMoney += 10;
            rebirthMoneyText = 10;
        }
        if (bits.currentBits > 1000000000 && bits.currentBits < 10000000000)
        {
            bits.numPasiveMoney += 12;
            rebirthMoneyText = 12;
        }
        if (bits.currentBits > 10000000000 && bits.currentBits < 100000000000)
        {
            bits.numPasiveMoney += 14;
            rebirthMoneyText = 14;
        }
        if (bits.currentBits > 100000000000 && bits.currentBits < 1000000000000)
        {
            bits.numPasiveMoney += 16;
            rebirthMoneyText = 16;
        }
        if (bits.currentBits > 1000000000000 && bits.currentBits < 10000000000000)
        {
            bits.numPasiveMoney += 18;
            rebirthMoneyText = 18;
        }
        if (bits.currentBits > 10000000000000)
        {
            bits.numPasiveMoney += 20;
            rebirthMoneyText = 20;
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
