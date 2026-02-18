using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class JobGenerator : MonoBehaviour
{
    public GameObject jobPrefab;
    public Transform contentParent;
    private string _jobType = "GDgodot";
    private const float RefreshInterval = 20f;
    public TextMeshProUGUI timeTillReset;
    

    private void Start()
    {
        _jobType = GlobalVariables.CareerPath switch
        {
            "GDgodot" => "Game in godot",
            "GDunity" => "Game in unity",
            "GDue" => "Game in unreal engine",
            "WDfrontend" => "Web Frontend",
            "WDbackend" => "Web Backend",
            "SEpython" => "Python",
            "SEjava" => "Java",
            _ => _jobType //pokud _jobType není nic z uvedenýho tak tam nechá co tam bylo
        };
        StartCoroutine(RestartJobOfferTimer());
    }

    private void GenerateJobs(int count)
    {
        if (GlobalVariables.JobOffers.Count == 0)
        {
            for (int i = 0; i < count; i++)
            {
                if (_jobType != null)
                {
                    
                    int time = Random.Range(1, 100); // v hodinach
                    int money = time * GlobalVariables.HourRate;
                    int xp = time * 3; //3 je random konstanta na násobení času k získání xp TODO
                    
                    
                    GlobalVariables.JobOffers.Add(new Job(_jobType, time, money, xp));
                }
            }
        }
    }

    private void InitiateJobs()
    {
        foreach (Job job in GlobalVariables.JobOffers)
        {
            GameObject newJob = Instantiate(jobPrefab, contentParent);
            newJob.GetComponent<SetupJob>().Setup(job);
        }
    }

    
    
    
    //TODO funkční timer i po zavření scény
    
    
    
    
    
    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator RestartJobOfferTimer()
    {
        while (true)
        {
            GenerateJobs(10);
            InitiateJobs();


            float timeLeft = RefreshInterval;

            while (timeLeft > 0)
            {
                if (timeTillReset != null)
                {
                    CalcTime((int)Mathf.Round(timeLeft), timeTillReset, 0);
                }
                yield return null;
                timeLeft -= Time.deltaTime;
            }
            ClearJobs();
        }
    }

    private void ClearJobs()
    {
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }
        GlobalVariables.JobOffers.Clear();
    }

    public static void CalcTime(int seconds, TextMeshProUGUI timeTillReset, int type) //type - 0 reset, 1 jobTimer
    {
        if (seconds > 60 && seconds % 60 != 0)
        {
            int minutes = seconds / 60;
            int remainingSeconds = seconds % 60;
            timeTillReset.text = type == 0 ? "Reset in: " + minutes + " minutes " + remainingSeconds + " s" : "Remaining: " + minutes + " minutes " + remainingSeconds + " s";
        }
        else if (seconds % 60 == 0 && seconds != 0)
        {
            int minutes = seconds / 60;
            timeTillReset.text = type == 0 ? "Reset in: " + minutes + " minutes" : "Remaining: " + minutes + " minutes";
        }
        else
        {
            timeTillReset.text =  type == 0 ? "Reset in: " + seconds + "seconds": "Remaining: " + seconds + " seconds";
        }
    }
}
