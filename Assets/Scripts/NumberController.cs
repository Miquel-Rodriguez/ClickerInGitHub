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

    [HideInInspector]
    public int[] whatSkinsPut = new int[] {0,1,2,3};

    [SerializeField] SkinsRecyclerView skinsRecyclerView;

    [Header("Info Panel Component")]
    [SerializeField] private SourceEnergy sourceEnergy;
    [SerializeField] private ProcessorComponent processorComponent;
    [SerializeField] private Storage storage;
    [SerializeField] private Graphic graphicCompoenent;

    private int numComponenet;
    [SerializeField] private TextMeshProUGUI textNameInfoPanel;
    [SerializeField] private TextMeshProUGUI textDescriptionInfoPanel;
    [SerializeField] private TextMeshProUGUI textStatsInfoPanel;
    [SerializeField] private TextMeshProUGUI textCost;





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


    public void SetInfoInPanel(int num)
    {
        numComponenet = num;
        switch (num)
        {
            case 0:
                
                SetUI(sourceEnergy.cName, sourceEnergy.description, sourceEnergy.statsDescription, sourceEnergy.cost);
                skinsRecyclerView.SetSkinsList(numComponenet);
                 break;
            case 1:
                SetUI(processorComponent.cName, processorComponent.description, processorComponent.statsDescription, processorComponent.cost);
                skinsRecyclerView.SetSkinsList(numComponenet);
                break;
            case 2:
                SetUI(storage.cName, storage.description, storage.statsDescription, storage.cost);
                skinsRecyclerView.SetSkinsList(numComponenet);
                break;
            case 3:
                SetUI(graphicCompoenent.cName, graphicCompoenent.description, graphicCompoenent.statsDescription, graphicCompoenent.cost);
                skinsRecyclerView.SetSkinsList(numComponenet);
                break;

        }
    }

    private void SetUI(string name, string description, string stats, float cost)
    {
        textNameInfoPanel.text = name;
        textDescriptionInfoPanel.text = description;
        textStatsInfoPanel.text = stats;
        textCost.text = BitUtil.StringFormat(cost, BitUtil.TextFormat.Long);
    }
}
