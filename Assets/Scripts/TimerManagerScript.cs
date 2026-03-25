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
    public static GameObject LoggedJobTimerImageBG;
    public static Image LoggedJobTimerImageFG;
    public static RectTransform TemporaryJobRt;
    public static GameObject LoggedPracticeTimerImageBG;
    public static Image LoggedPracticeTimerImageFG;
    public static RectTransform TemporaryPracticeRt;
    
    
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
        LoggedJobTimerImageBG.SetActive(true);
        float totalToGrow = 200f;
        float duration = jobTime;
        float growthPerSecond = totalToGrow / duration;
        CurrentJobTimeLeft = jobTime * GlobalVariables.SpeedMultiplier;
        
        while (CurrentJobTimeLeft > 0)
        {
            yield return null;
            CurrentJobTimeLeft -= Time.deltaTime;
            GlobalVariables.CurrentJobTimerSliderValue += growthPerSecond * Time.deltaTime;

            if (!LoggedJobTimerImageBG || !LoggedJobTimerImageFG || !TemporaryJobRt) continue;

            if (GlobalVariables.HasJob && GlobalVariables.ActiveScene == "Desktop")
            {
                LoggedJobTimerImageBG.SetActive(true);
                TemporaryJobRt.sizeDelta = new Vector2(GlobalVariables.CurrentJobTimerSliderValue, 30);
            }
        }
        
        GlobalVariables.HasJob = false;
        JobFinished?.Invoke();
        LoggedJobTimerImageBG.SetActive(false);
        GlobalVariables.CurrentJobTimerSliderValue = 0;
        GlobalVariables.Money += (int)Mathf.Round(jobMoney * GlobalVariables.QualityMultiplier);
        GlobalVariables.Xp += jobXp;
        GlobalVariables.LevelUp();
        
        if (JobManager.Instance)
        {
            JobManager.Instance.RefreshUI();
        }
    }

    public static IEnumerator PracticingTimer(int practiceType) //0 - quality, 1 - speed
    {
        LoggedPracticeTimerImageBG.SetActive(true);
        switch (practiceType)
        {
            case 0: PracticingTimeLeft = GlobalVariables.QualityPractisingTime; break;
            case 1: PracticingTimeLeft = GlobalVariables.SpeedPractisingTime; break;
        }
        
        float totalToGrow = 200f;
        float duration = PracticingTimeLeft;
        float growthPerSecond = totalToGrow / duration;

        while (PracticingTimeLeft > 0)
        {
            yield return null;
            PracticingTimeLeft -= Time.deltaTime;
            GlobalVariables.CurrentPracticeTimerSliderValue += growthPerSecond * Time.deltaTime;

            if (!LoggedPracticeTimerImageBG || !LoggedPracticeTimerImageFG || !TemporaryPracticeRt) continue;

            if (GlobalVariables.IsPracticing && GlobalVariables.ActiveScene == "Desktop")
            {
                LoggedPracticeTimerImageBG.SetActive(true);
                TemporaryPracticeRt.sizeDelta = new Vector2(GlobalVariables.CurrentPracticeTimerSliderValue, 30);
            }
        }
        
        LoggedPracticeTimerImageBG.SetActive(false);
        GlobalVariables.CurrentPracticeTimerSliderValue = 0;
        
        if (JobManager.Instance)
        {
            JobManager.Instance.RefreshUI();
        }
    }
}