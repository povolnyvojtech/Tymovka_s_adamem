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
    
    public void Setup(string jobType, int time, int money, int jobXp)
    {
        typeText.text = "Type of job: " + jobType;
        timeText.text = "Time: " + time;
        moneyText.text = "Money: " + money;
        
        _jobMoney = money;
        _jobTime = time;
        _jobXp = jobXp;
    }
    
    public void ActivateJob()
    {
        JobManager.Instance.StartContract(_jobTime, _jobMoney, _jobXp);
    }
}
