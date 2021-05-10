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

    [SerializeField] private TextMeshProUGUI bitText;

    [SerializeField] private GameObject allSkins;
    [SerializeField] private Image[] wherePutSkins;


    public int[] whatSkinsPut = new int[] {0,1,2,3};


    void Start()
    {
        SetSkins();
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

    public void SetSkins()
    {
       for(int i=0; i<wherePutSkins.Length; i++)
        {
            wherePutSkins[i].sprite = allSkins.transform.GetChild(whatSkinsPut[i]).gameObject.GetComponent<Skin>().spriteSkin;
        }
    }

}
