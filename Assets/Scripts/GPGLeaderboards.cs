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
        if (PlayerPrefs.GetInt("ScoreToUpdate", 0) == 0)
        {
            return;
        }

        Social.ReportScore(PlayerPrefs.GetInt("ScoreToUpdate", 1), GPGSIds.leaderboard_score, (bool succes) =>
        {
            if (succes)
            {
                PlayerPrefs.SetInt("ScoreToUpdate", 0);
            }
        });
    }
}
