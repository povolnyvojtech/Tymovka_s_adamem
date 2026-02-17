using System.Collections;
using UnityEngine;

public class JobManager : MonoBehaviour
{
    public static JobManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    public void StartContract(int jobTime, int jobMoney, int jobXp)
    {
        StartCoroutine(TimerRoutine(jobTime, jobMoney, jobXp));
    }

    private IEnumerator TimerRoutine(int seconds, int jobMoney, int jobXp)
    {
        Debug.Log("Job has been accepted - " + seconds + " - " + jobMoney + "$");
        yield return new WaitForSeconds(seconds);
        GlobalVariables.Money += jobMoney;
        GlobalVariables.Xp += jobXp;
        GlobalVariables.CheckXp();
        Debug.Log("Money: " + GlobalVariables.Money + " + " + GlobalVariables.Xp + "XP");
    }
}