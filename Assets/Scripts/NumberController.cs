using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberController : MonoBehaviour
{

    public static int score = 0;
    public TextMeshProUGUI scoreText;

    [SerializeField] EnergyBar energyBarController;
   // [SerializeField] public float bitPerClick;
    //[SerializeField] public double bitPerSecond;
    [SerializeField] public int energyPerClick;
    [SerializeField] public int totalEnergy;
    [SerializeField] public int energyRecovery;
    [SerializeField] public float currentBits=0;
    [SerializeField] public int missionCounter = 0;

    [SerializeField] private TextMeshProUGUI bitText;

    [Header("Skins Recycler")]
    [SerializeField] private GameObject allSkins;
    [SerializeField] private Image[] wherePutSkins;

    [HideInInspector]
    public int[] whatSkinsPut = new int[] {0,1,2,3};

    [SerializeField] SkinsRecyclerView skinsRecyclerView;

    [Header("Components")]
    [SerializeField] private SourceEnergy sourceEnergy;
    [SerializeField] private ProcessorComponent processorComponent;
    [SerializeField] private Storage storage;
    [SerializeField] private Graphic graphicCompoenent;

    private int numComponenet;
    [SerializeField] private TextMeshProUGUI textNameInfoPanel;
    [SerializeField] private TextMeshProUGUI textDescriptionInfoPanel;
    [SerializeField] private TextMeshProUGUI textStatsInfoPanel;
    [SerializeField] private TextMeshProUGUI textCost;
    [SerializeField] private TextMeshProUGUI textLvl;
    public GameObject animationScript, mouseAnimation;

    [Header("Money Texts")]

    [SerializeField] private TextMeshProUGUI textDolares;
    [SerializeField] private TextMeshProUGUI textPasiveMoney;
    [SerializeField] private TextMeshProUGUI textHardCurrency;
    [SerializeField] public TextMeshProUGUI counterMissions;

    public int numDolars;
    public int numPasiveMoney;
    public int dogeCoins;
    void Start()
    {
        SetMoney();
        SetSkins();
    }

    private void SetMoney()
    {
        textDolares.text = numDolars.ToString();
        textPasiveMoney.text = numPasiveMoney.ToString();
        textHardCurrency.text = dogeCoins.ToString();
    }

    
    void Update()
    {
      
    }

    private void FixedUpdate()
    {
        if (MaxCapacity())
        {
            currentBits += graphicCompoenent.bitesForSeocnd * Time.deltaTime;

            string delay = BitUtil.StringFormat(currentBits, BitUtil.TextFormat.Long) + "/" + BitUtil.StringFormat(storage.maxBitesCapacity, BitUtil.TextFormat.Long);
            bitText.text = delay;
        }
        else
        {
            currentBits = storage.maxBitesCapacity;
            bitText.text = BitUtil.StringFormat(currentBits, BitUtil.TextFormat.Long) + "/" + BitUtil.StringFormat(storage.maxBitesCapacity, BitUtil.TextFormat.Long);
        }
       
        
    }

    public void incrementalScore()
    {
       
        PlayerPrefs.SetFloat("ScoreToUpdate", currentBits);
    }

    public void RestBits(float bits)
    {
        currentBits -= bits;
        bitText.text = BitUtil.StringFormat(currentBits, BitUtil.TextFormat.Long);
    }



    public void ClickOnByteButton()
    {
        if (MaxCapacity() && energyBarController.DownBar())
        {
            currentBits += processorComponent.bitesPerClick;
            string delay = BitUtil.StringFormat(currentBits, BitUtil.TextFormat.Long) + "/" + BitUtil.StringFormat(storage.maxBitesCapacity, BitUtil.TextFormat.Long);
            bitText.text = delay;       
            animationScript.GetComponent<RandomAnimation>().startAnimation();
            mouseAnimation.GetComponent<Animator>().SetTrigger("Click");

        }

    }

    private bool MaxCapacity()
    {
        if (storage.maxBitesCapacity >= (currentBits + processorComponent.bitesPerClick))
        {
            return true;
        }
        else return false;
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
                
                SetUI(sourceEnergy.cName, sourceEnergy.description, sourceEnergy.statsDescription, sourceEnergy.cost, sourceEnergy.lvl);
                skinsRecyclerView.SetSkinsList(numComponenet);
                 break;
            case 1:
                SetUI(processorComponent.cName, processorComponent.description, processorComponent.statsDescription, processorComponent.cost, processorComponent.lvl);
                skinsRecyclerView.SetSkinsList(numComponenet);
                break;
            case 2:
                SetUI(storage.cName, storage.description, storage.statsDescription, storage.cost, storage.lvl);
                skinsRecyclerView.SetSkinsList(numComponenet);
                break;
            case 3:
                SetUI(graphicCompoenent.cName, graphicCompoenent.description, graphicCompoenent.statsDescription, graphicCompoenent.cost,graphicCompoenent.lvl);
                skinsRecyclerView.SetSkinsList(numComponenet);
                break;

        }
    }

    private void SetUI(string name, string description, string stats, float cost, int level)
    {
        textNameInfoPanel.text = name;
        textDescriptionInfoPanel.text = description;
        textStatsInfoPanel.text = stats;
        textCost.text = BitUtil.StringFormat(cost, BitUtil.TextFormat.Long);
        textLvl.text = "Lvl "+level.ToString();
    }


    public void LevelUp()
    {
        switch (numComponenet)
        {
            case 0:
                if (currentBits >= sourceEnergy.cost)
                {
                    RestBits(sourceEnergy.cost);
                    sourceEnergy.LevelUP();
                    SetUI(sourceEnergy.cName, sourceEnergy.description, sourceEnergy.statsDescription, sourceEnergy.cost, sourceEnergy.lvl);
                }
                else
                {
                    StartCoroutine(ChangeTextColor());
                }
                break;
            case 1:
                if (currentBits >= processorComponent.cost)
                {
                    RestBits(processorComponent.cost);
                    processorComponent.LevelUP();
                    SetUI(processorComponent.cName, processorComponent.description, processorComponent.statsDescription, processorComponent.cost, processorComponent.lvl);
                }
                else
                {
                    StartCoroutine(ChangeTextColor());
                }
                break;
            case 2:
                if (currentBits >= storage.cost)
                {
                    RestBits(storage.cost);
                    storage.LevelUP();
                    SetUI(storage.cName, storage.description, storage.statsDescription, storage.cost, storage.lvl);
                }
                else
                {
                    StartCoroutine(ChangeTextColor());
                }
                break;
            case 3:
                if (currentBits >= graphicCompoenent.cost)
                {
                    RestBits(graphicCompoenent.cost);
                    graphicCompoenent.LevelUP();
                    SetUI(graphicCompoenent.cName, graphicCompoenent.description, graphicCompoenent.statsDescription, graphicCompoenent.cost, graphicCompoenent.lvl);
                }
                else
                {
                    StartCoroutine(ChangeTextColor());
                }
                break;
        }
    }

    private IEnumerator ChangeTextColor()
    {
        textCost.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        textCost.color = Color.white;
    }

    public bool missionComplete(float requiredBits, int reward) {
        if (currentBits >= requiredBits)
        {
            RestBits(requiredBits);
            numDolars += reward;
            textDolares.SetText(numDolars+"");
            missionCounter++;
            setCounterText();
            return true;
        }
        else {
            return false;
        }

    }

    public void setCounterText() {
        counterMissions.SetText(missionCounter.ToString());
    }
}
