using System;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using TMPro;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static int HallBgLevel = 0;
    public static int CurrentHallBgUpgradeCost = 600;
    public static int BedroomBgLevel = 0;
    public static int CurrentBedroomBgUpgradeCost = 500;

    public static int QualityLevel = 1;
    public static float QualityMultiplier = 1f;
    public static int SpeedLevel = 1;
    public static float SpeedMultiplier = 1f;
    public static bool IsPracticing = false;
    public static int QualityPractisingTime = 20;
    public static int SpeedPractisingTime = 20;
    public static int CurrentPracticingType = 2;
    
    public static bool HasCareer = false;
    public static string CareerPath = "None"; //vždy formát - TYPPROFESEzamereni - GDgodot 

    public static int Money = 450;
    
    public static int HourRate = 10; //- hodinova sazba (cim vetsi Level, tim vetsi sazba)
    private static int _level = 1;
    public static int Xp;
    
    public static List<Job> JobOffers =  new List<Job>();

    public static bool HasJob = false;
    public static int CurrentJobMoney;
    
    
    public static void LevelUp()
    {
        _level = (Xp / 150) < 1 ? 1 : Xp / 150;
        HourRate += (_level % 10 == 0) ? 5 : 0;
    }
    
    public static void UpdateStats(TextMeshProUGUI levelText, TextMeshProUGUI xpText, TextMeshProUGUI moneyText)
    {
        levelText.text = "Level: " + _level;
        xpText.text = "Xp: " + Xp;
        moneyText.text = "Money: " + Money;
    }
    
    public static void UpdateJobStats(float currentJobTimeLeft, TextMeshProUGUI jobRemainingTimeStatsText, TextMeshProUGUI jobMoneyStatsText, int currentJobMoney)
    {
        if (currentJobTimeLeft > 0 && jobRemainingTimeStatsText && jobMoneyStatsText && HasJob)
        {
            CalcTime((int)Mathf.Round(currentJobTimeLeft), jobRemainingTimeStatsText, 1);
            jobMoneyStatsText.text = "Money: " + currentJobMoney;
            return;
        }
        jobRemainingTimeStatsText.text = "You have no current job";
        jobMoneyStatsText.text = "";
    }
    
    public static void UpdatePracticeStats(float practiceTimeLeft, TextMeshProUGUI practiceRemainingTimeStatsText, TextMeshProUGUI practiceRewardStatsText, int practiceType) //type - 0 - quality, 1 - speed, 2 - nothing 
    {
        if (practiceTimeLeft > 0 && practiceRemainingTimeStatsText && IsPracticing)
        {
            CalcTime((int)Mathf.Round(practiceTimeLeft), practiceRemainingTimeStatsText, 1);
            practiceRewardStatsText.text = practiceType switch
            {
                0 => "Reward: Quality multiplier -> " + (QualityMultiplier + 0.1f),
                1 => "Reward: Speed multiplier -> " + (SpeedMultiplier - 0.07f),
                2 => "",
                _ => throw new ArgumentOutOfRangeException(nameof(practiceType), practiceType, null)
            };
            return;
        }
        practiceRemainingTimeStatsText.text = "You are not practicing at the moment";
        practiceRewardStatsText.text = "";
    }
    
    
    
    public static void CalcTime(int seconds, TextMeshProUGUI timeTillReset, int type) //type - 0 reset, 1 jobTimer
    {
        if (seconds > 60 && seconds % 60 != 0)
        {
            int minutes = seconds / 60;
            int remainingSeconds = seconds % 60;
            timeTillReset.text = type == 0 ? "Reset in: " + minutes + " minutes " + remainingSeconds + " seconds" : "Remaining: " + minutes + " minutes " + remainingSeconds + " seconds";
        }
        else if (seconds % 60 == 0 && seconds != 0)
        {
            int minutes = seconds / 60;
            timeTillReset.text = type == 0 ? "Reset in: " + minutes + " minutes" : "Remaining: " + minutes + " minutes";
        }
        else
        {
            timeTillReset.text =  type == 0 ? "Reset in: " + seconds + " seconds" : "Remaining: " + seconds + " seconds";
        }
    }
}
