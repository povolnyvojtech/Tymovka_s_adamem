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
    private string _jobType;
    private const float RefreshInterval = 10f;
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
        for (int i = 0; i < count; i++)
        {
            if (_jobType != null)
            {
                GameObject newJob = Instantiate(jobPrefab, contentParent);
                int time = Random.Range(20,70); // v hodinach
                int money = time * GlobalVariables.HourRate;
                int xp = time * 3; //3 je random konstanta na násobení času k získání xp TODO
                
                newJob.GetComponent<SetupJob>().Setup(_jobType, time, money, xp);
            }
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator RestartJobOfferTimer()
    {
        while (true)
        {
            ClearJobs();
            GenerateJobs(10);
            
            float timeLeft = RefreshInterval;

            while (timeLeft > 0)
            {
                if (timeTillReset != null)
                {
                    CalcTime((int)Mathf.Round(timeLeft));
                }
                yield return null;
                timeLeft -= Time.deltaTime;
            }
        }
    }

    private void ClearJobs()
    {
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }
    }

    private void CalcTime(int seconds)
    {
        if (seconds > 60 && seconds % 60 != 0)
        {
            int minutes = seconds / 60;
            int remainingSeconds = seconds % 60;
            timeTillReset.text = "Reset in: " + minutes + " minutes " + remainingSeconds + " s";
        }
        else if (seconds % 60 == 0 && seconds != 0)
        {
            int minutes = seconds / 60;
            timeTillReset.text = "Reset in: " + minutes + " minutes";
        }
        else
        {
            timeTillReset.text = "Reset in: " + seconds + " s";
        }
    }
}
