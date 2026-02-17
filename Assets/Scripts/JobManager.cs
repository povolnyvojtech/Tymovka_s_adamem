using System.Collections;
using UnityEngine;

public class JobManager : MonoBehaviour
{
    public static JobManager Instance { get; private set; }
    private bool _hasJob = false;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    public void StartContract(int jobTime, int jobMoney, int jobXp)
    {
        if (_hasJob) return;
        StartCoroutine(TimerRoutine(jobTime, jobMoney, jobXp));
        _hasJob = true;
    }

    private IEnumerator TimerRoutine(int seconds, int jobMoney, int jobXp)
    {
        Debug.Log("Job has been accepted - " + seconds + " - " + jobMoney + "$");
        yield return new WaitForSeconds(seconds);
        _hasJob = false;
        GlobalVariables.Money += jobMoney;
        GlobalVariables.Xp += jobXp;
        GlobalVariables.LevelUp();
        Debug.Log("Money: " + GlobalVariables.Money + " + " + GlobalVariables.Xp + "XP " + "+ " + GlobalVariables.Level);
    }
}