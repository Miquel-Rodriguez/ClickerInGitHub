using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPGLeaderboards : MonoBehaviour
{
    public void OepnLeaderboard()
    {
        Social.ShowLeaderboardUI();
    }

    public void UpdateLeaderboardScore()
    {

        Social.ReportScore((long)PlayerPrefs.GetFloat("ScoreToUpdate", 1), GPGSIds.leaderboard_score, (bool succes) =>
        {
            Debug.Log(succes);
        });
    }
}
