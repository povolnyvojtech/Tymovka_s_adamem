using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerManagerScript : MonoBehaviour
{
    public static TimerManagerScript Instance {get; private set;}
    private const float RefreshInterval = 20f;
    public static float JobOffersTimeLeft;
    public static float CurrentJobTimeLeft;
    public static float PracticingTimeLeft;
    
    
    public static event Action JobFinished;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            StartCoroutine(RestartJobOfferTimer());
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private static IEnumerator RestartJobOfferTimer()
    {
        while (true)
        {
            JobOffersTimeLeft = RefreshInterval;
        
            while (JobOffersTimeLeft > 0)
            {
                yield return null;
                JobOffersTimeLeft -= Time.deltaTime;
            }
            yield return new WaitForSeconds(0.2f); 
        }
    }

    public static IEnumerator CurrentJobTimer(int jobTime, int jobMoney, int jobXp)
    {
        CurrentJobTimeLeft = jobTime * GlobalVariables.SpeedMultiplier;

        while (CurrentJobTimeLeft > 0)
        {
            yield return null;
            CurrentJobTimeLeft -= Time.deltaTime;
        }

        JobFinished.Invoke();
        GlobalVariables.HasJob = false;
        GlobalVariables.Money += (int)Mathf.Round(jobMoney * GlobalVariables.QualityMultiplier);
        GlobalVariables.Xp += jobXp;
        GlobalVariables.LevelUp();
        
        if (JobManager.Instance)
        {
            JobManager.Instance.RefreshUI();
        }
    }

    public static IEnumerator PracticingTimer(int practiceType, Image bg, Image fg) //0 - quality, 1 - speed
    {
        switch (practiceType)
        {
            case 0: PracticingTimeLeft = GlobalVariables.QualityPractisingTime; break;
            case 1: PracticingTimeLeft = GlobalVariables.SpeedPractisingTime; break;
        }

        RectTransform rt = fg.GetComponent<RectTransform>();
        float totalToGrow = 200f;
        float duration = PracticingTimeLeft;
        float growthPerSecond = totalToGrow / duration;

        while (PracticingTimeLeft > 0)
        {
            yield return null;
            rt.sizeDelta += new Vector2(growthPerSecond * Time.deltaTime, 0);
            PracticingTimeLeft -= Time.deltaTime;
        }

        if (JobManager.Instance)
        {
            JobManager.Instance.RefreshUI();
        }
    }
}