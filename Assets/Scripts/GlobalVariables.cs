using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static int HallBgLevel = 0;
    public static int BedroomBgLevel = 0;
    public static bool HasCareer = false;
    public static string CareerPath = "None"; //vždy formát - TYPPROFESEzamereni - GDgodot 

    public static int Money = 1000;
    
    public static int HourRate = 10; //- hodinova sazba (cim vetsi Level, tim vetsi sazba)
    public static int Level = 1;
    public static int Xp;
    
    public static List<Job> JobOffers =  new List<Job>();

    public static bool HasJob = false;
    public static int CurrentJobMoney;
    
    public static void LevelUp()
    {
        Level = (Xp / 150) < 1 ? 1 : Xp / 150;
        HourRate += (Level % 10 == 0) ? 5 : 0;
    }
    
    public static void UpdateStats(TextMeshProUGUI levelText, TextMeshProUGUI xpText, TextMeshProUGUI moneyText)
    {
        levelText.text = "Level: " + Level;
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
