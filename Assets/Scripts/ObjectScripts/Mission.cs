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
    public GameObject numberController;

    void Start()
    {
        nameText.SetText(missionName);
        descText.SetText(missionDescription);
        if (missionID > 0 && missionID <= 5) {
            requiredBits = Random.Range(5f, 20f);
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
                Destroy(this.gameObject);
            }
            else {
                completed = false;
            }
        }
    }

    
}
