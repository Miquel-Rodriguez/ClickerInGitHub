using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;

public class GPHAchievements : MonoBehaviour
{
    [SerializeField] NumberController bits;
    public void openAchievementPanel()
    {
        Social.ShowAchievementsUI();
    }

    public void Tap10Times()
    {
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_tapping_begginer, 1, null);
    }

    public void UnlockShop()
    {
        Social.ReportProgress(GPGSIds.achievement_shopping, 100f, null);
    }

    public void UnlockCredits()
    {
        Social.ReportProgress(GPGSIds.achievement_a_pretty_short_credits, 100f, null);
    }

    public void Get10000Bits()
    {
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_getting_bits, (int)bits.currentBits, null);
    }

    public void Get100000Bits()
    {
        Social.ReportProgress(GPGSIds.achievement_more_and_more_bits, 100f, null);
    }

    public void GetAMillionBits()
    {
        Social.ReportProgress(GPGSIds.achievement_a_million, 100f, null);
    }

    public void GetABillionBits()
    {
        Social.ReportProgress(GPGSIds.achievement_a_billion, 100f, null);
    }

    public void GetAQuadrillionBits()
    {
        Social.ReportProgress(GPGSIds.achievement_more_bits_than_elon_musk, 100f, null);
    }

}
