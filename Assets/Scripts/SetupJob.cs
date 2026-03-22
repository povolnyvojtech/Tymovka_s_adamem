using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetupJob : MonoBehaviour
{
    public TextMeshProUGUI typeText;
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
        float finalTime = _jobData.JobTime * GlobalVariables.SpeedMultiplier;
        float finalMoney = _jobData.JobMoney * GlobalVariables.QualityMultiplier;
        
        typeText.text = _jobData.JobType;
        moneyText.text = "Money: " + finalMoney;
        
        _jobMoney = (int)finalMoney;
        _jobTime = (int)finalTime;
        _jobXp = _jobData.JobXp;
    }
    
    public void ShowContractStats()
    {
        GlobalVariables.JobGameObject = gameObject;
        DisplayContractInfo.Instance.DisplayStats(_jobTime, _jobMoney, _jobXp, _jobData.JobType, 0);
        GlobalVariables.CurrentJob = _jobData;
    }
}