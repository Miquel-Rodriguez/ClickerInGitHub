using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] NumberController bits;
    [SerializeField] int numPowerUp;
    [SerializeField] EnergyBar energy;

    private IEnumerator moreTypesForByte( int numRarity)
    {
        if (numRarity == 1)
        {
            bits.bitPerClick *= 2;
            yield return new WaitForSeconds(10f);
            bits.bitPerClick /= 2;
        }else if (numRarity == 2)
        {
            bits.bitPerClick *= 3;
            yield return new WaitForSeconds(20f);
            bits.bitPerClick /= 3;
        }
        else if (numRarity == 3)
        {
            bits.bitPerClick *= 5;
            yield return new WaitForSeconds(20f);
            bits.bitPerClick /= 5;
        }
    }

    private IEnumerator noEnergyCost(int numRarity)
    {
        float aux = 0;
        if (numRarity == 1)
        {
            aux = energy.energyCostForClick;
            energy.energyCostForClick = 0;
            yield return new WaitForSeconds(15f);
            energy.energyCostForClick = aux;
        }
        else if (numRarity == 2)
        {
            aux = energy.energyCostForClick;
            energy.energyCostForClick = 0;
            yield return new WaitForSeconds(30f);
            energy.energyCostForClick = aux;
        }
        else if (numRarity == 3)
        {
            aux = energy.energyCostForClick;
            energy.energyCostForClick = 0;
            yield return new WaitForSeconds(60f);
            energy.energyCostForClick = aux;
        }
    }
       

    public void normalBytes()
    {
        StartCoroutine(moreTypesForByte(1));
    }

    public void rareBytes()
    {
        StartCoroutine(moreTypesForByte(2));
    }

    public void legendaryBytes()
    {
        StartCoroutine(moreTypesForByte(3));
    }

    public void normalEnergy()
    {
        StartCoroutine(noEnergyCost(1));
    }

    public void rareEnergy()
    {
        StartCoroutine(noEnergyCost(2));
    }

    public void legendaryEnergy()
    {
        StartCoroutine(noEnergyCost(3));
    }

}
