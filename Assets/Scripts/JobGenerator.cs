using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class JobGenerator : MonoBehaviour
{
    public GameObject jobPrefab;
    public Transform contentParent;
    private string _jobType = "GDgodot";

    private void Start()
    {
        _jobType = GlobalVariables.CareerPath switch
        {
            "GDgodot" => "Game in godot",
            "GDunity" => "Game in unity",
            "GDue" => "Game in unreal engine",
            "WDfrontend" => "Frontend",
            "WDbackend" => "Backend",
            "SEpython" => "Python",
            "SEjava" => "Java",
            _ => _jobType //pokud _jobType není nic z uvedenýho tak tam nechá co tam bylo
        };

        GenerateJobs(10);
    }

    private void GenerateJobs(int count)
    {
        
        for (var i = 0; i < count; i++)
        {
            if (_jobType != null)
            {
                GameObject newJob = Instantiate(jobPrefab, contentParent);
                var time = Random.Range(0, 100);
                var money = Random.Range(0, 12);
                newJob.GetComponent<SetupJob>().Setup(_jobType, money, time);
            }
        }
    }
}
