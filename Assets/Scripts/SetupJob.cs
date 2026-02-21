using System.Collections;
using TMPro;
using UnityEngine;

public class SetupJob : MonoBehaviour
{
    public TextMeshProUGUI typeText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI moneyText;

    private Job _jobData;
    private int _jobTime;
    private int _jobMoney;
    private int _jobXp;
    
    public void Setup(Job job)
    {
        _jobData = job;
        RefreshUI();
    }
    
    public void RefreshUI()
    {
        if (_jobData == null) return;
        float finalMoney = _jobData.JobTime * GlobalVariables.SpeedMultiplier;
        float finalTime = _jobData.JobMoney * GlobalVariables.QualityMultiplier;
        
        typeText.text = "Type of job: " + _jobData.JobType;
        timeText.text = "Time: " + _jobData.JobTime + " * SM("+GlobalVariables.SpeedMultiplier + ") => " + finalMoney;
        moneyText.text = "Money: " + _jobData.JobMoney + " * QM(" + GlobalVariables.QualityMultiplier + ") => " + finalTime;
        
        _jobMoney = (int)finalMoney;
        _jobTime = (int)finalTime;
        _jobXp = _jobData.JobXp;
    }
    
    public void ActivateJob()
    {
        JobManager.Instance.StartContract(_jobTime, _jobMoney, _jobXp);
        Destroy(gameObject);
    }
}