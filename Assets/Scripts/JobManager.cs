using System.Collections;
using TMPro;
using UnityEngine;

public class JobManager : MonoBehaviour
{
    public static JobManager Instance { get; private set; }
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI xpText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI jobRemainingTimeStatsText;
    public TextMeshProUGUI jobMoneyStatsText;
    private bool _hasJob;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
        UpdateStats();
    }
    
    private void UpdateStats()
    {
        levelText.text = "Level: " + GlobalVariables.Level;
        xpText.text = "Xp: " + GlobalVariables.Xp;
        moneyText.text = "Money: " + GlobalVariables.Money;
    }
    
    private void UpdateJobStats()
    {
        jobRemainingTimeStatsText.text = "You have no current job";
        jobMoneyStatsText.text = "";
    }

    public void StartContract(int jobTime, int jobMoney, int jobXp)
    {
        if (_hasJob) return;
        _hasJob = true;
        StartCoroutine(JobRoutine(jobTime, jobMoney, jobXp));
        StartCoroutine(JobTimer(jobTime));
        jobMoneyStatsText.text = "Money: " + jobMoney;
    }

    private IEnumerator JobRoutine(int seconds, int jobMoney, int jobXp)
    {
        yield return new WaitForSeconds(seconds);
        _hasJob = false;
        UpdateJobStats();
        GlobalVariables.Money += jobMoney;
        GlobalVariables.Xp += jobXp;
        GlobalVariables.LevelUp();
        UpdateStats();
    }
    
    private IEnumerator JobTimer(int jobTime)
    {
        float timeLeft = jobTime;

        while (timeLeft > 0)
        {
            if (jobRemainingTimeStatsText)
            {
                JobGenerator.CalcTime((int)Mathf.Ceil(timeLeft), jobRemainingTimeStatsText, 1);
            }

            yield return null;
            timeLeft -= Time.deltaTime;
        }
    }
}