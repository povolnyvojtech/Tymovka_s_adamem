using System.Collections;
using TMPro;
using UnityEngine;

public class SetupJob : MonoBehaviour
{
    public TextMeshProUGUI typeText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI moneyText;

    private int _jobTime;
    private int _jobMoney;
    private int _jobXp;
    
    public void Setup(Job job)
    {
        typeText.text = "Type of job: " + job.JobType;
        timeText.text = "Time: " + job.JobTime;
        moneyText.text = "Money: " + job.JobMoney;
        
        _jobMoney = job.JobMoney;
        _jobTime = job.JobTime;
        _jobXp = job.JobXp;
    }
    
    public void ActivateJob()
    {
        JobManager.Instance.StartContract(_jobTime, _jobMoney, _jobXp);
    }
}
