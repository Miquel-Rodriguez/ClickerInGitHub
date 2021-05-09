using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberController : MonoBehaviour
{

    [SerializeField] EnergyBar energyBarController;
    [SerializeField] public float bitPerClick;
    [SerializeField] public double bitPerSecond;
    [SerializeField] public int energyPerClick;
    [SerializeField] public int totalEnergy;
    [SerializeField] public int energyRecovery;
    [SerializeField] public float currentBits=0;

    [SerializeField] GameObject contenedorSkins;

    [SerializeField] private TextMeshProUGUI bitText;


    void Start()
    {
        SetInicialSkins();
    }

    
    void Update()
    {
        
    }

    public void RestBits(float bits)
    {
        currentBits -= bits;
        bitText.text = BitUtil.StringFormat(currentBits, BitUtil.TextFormat.Long);
    }


    public void ClickOnByteButton()
    {

    }

    public void SetInicialSkins()
    {
       
    }

}
