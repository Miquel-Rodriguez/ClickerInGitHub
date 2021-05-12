using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberController : MonoBehaviour
{

    public static int score = 0;
    public TextMeshProUGUI scoreText;

    [SerializeField] EnergyBar energyBarController;
    [SerializeField] public float bitPerClick;
    [SerializeField] public double bitPerSecond;
    [SerializeField] public int energyPerClick;
    [SerializeField] public int totalEnergy;
    [SerializeField] public int energyRecovery;
    [SerializeField] public float currentBits=0;




    public void incrementalScore()
    {
        score++;
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("ScoreToUpdate", PlayerPrefs.GetInt("ScoreToUpdate", 0) + 1);
    }
   


}
