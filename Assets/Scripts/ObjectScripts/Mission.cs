using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class Mission : MonoBehaviour
{
    [Header("Mission's attributes")]
    public int missionID;
    public string missionName;
    public string missionDescription;
    public float requiredBits;
    public int reward;
    public bool completed = false;
    [Header("Text to adapt")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descText;
    public TextMeshProUGUI bitsText;
    public TextMeshProUGUI rewardText;
    [Header("External components")]
    public GameObject numberController, generator;

    void Start()
    {
        nameText.SetText(missionName);
        descText.SetText(missionDescription);
        if (missionID >= 0 && missionID <= 5) {
            requiredBits = Random.Range(1f, 160f);
        }
        bitsText.SetText(BitUtil.StringFormat(requiredBits, BitUtil.TextFormat.Long));
        reward = Random.Range(10,50);
        rewardText.SetText(reward + "$");
    }

    public void completeMission() {
        if (!completed) {
            if (numberController.GetComponent<NumberController>().missionComplete(requiredBits,reward))
            {
                completed = true;
                int misionesCompletadas = PlayerPrefs.GetInt("misionesCompletadas");
                misionesCompletadas++;
                PlayerPrefs.SetInt("misionesCompletadas",misionesCompletadas);
                Debug.Log(PlayerPrefs.GetInt("misionesCompletadas"));
                if (numberController.GetComponent<NumberController>().missionCounter == 3)
                {
                    numberController.GetComponent<NumberController>().missionCounter = 0;
                    generator.GetComponent<GenerateMissions>().deleteAllMissions();
                    generator.GetComponent<GenerateMissions>().generate5Missions();
                }
                else {
                    generator.GetComponent<GenerateMissions>().deleteMission(missionID);
                    Destroy(this.gameObject);
                }
                
            }
            else {
                completed = false;
            }
        }
    }

    
}
