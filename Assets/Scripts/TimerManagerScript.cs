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

    public static IEnumerator CurrentJobTimer(int jobTime, int jobMoney, int jobXp, GameObject timerImageBG, Image timerImageFG)
    {
        timerImageBG.SetActive(true);
        RectTransform rt = timerImageFG.GetComponent<RectTransform>();
        float totalToGrow = 200f;
        float duration = jobTime;
        float growthPerSecond = totalToGrow / duration;
        CurrentJobTimeLeft = jobTime * GlobalVariables.SpeedMultiplier;
        
        while (CurrentJobTimeLeft > 0)
        {
            yield return null;
            CurrentJobTimeLeft -= Time.deltaTime;
            GlobalVariables.CurrentJobTimerSliderValue += growthPerSecond * Time.deltaTime;

            if (!timerImageBG || !timerImageFG  || !rt)
            {
                timerImageBG = LoggedJobTimerImageBG;
                timerImageFG = LoggedJobTimerImageFG;
                if (timerImageFG) rt = timerImageFG.GetComponent<RectTransform>();
            }

            if (!timerImageBG || !timerImageFG || !rt) continue;

            if (GlobalVariables.HasJob && GlobalVariables.ActiveScene == "Desktop")
            {
                timerImageBG.SetActive(true);
                rt.sizeDelta = new Vector2(GlobalVariables.CurrentJobTimerSliderValue, 30);
            }
        }
        
        GlobalVariables.HasJob = false;
        JobFinished?.Invoke();
        timerImageBG.SetActive(false);
        GlobalVariables.Money += (int)Mathf.Round(jobMoney * GlobalVariables.QualityMultiplier);
        GlobalVariables.Xp += jobXp;
        GlobalVariables.LevelUp();
        
        if (JobManager.Instance)
        {
            JobManager.Instance.RefreshUI();
        }
    }

    //TODO MUSÍŠ TO PŘEKOPAT PROTOŽE timerImageBG a timerImageFG nepotřebuješ, oni se sami nastaví v LogSliderToScript
    public static IEnumerator PracticingTimer(int practiceType, GameObject timerImageBG, Image timerImageFG) //0 - quality, 1 - speed
    {
        timerImageBG.SetActive(true);
        switch (practiceType)
        {
            case 0: PracticingTimeLeft = GlobalVariables.QualityPractisingTime; break;
            case 1: PracticingTimeLeft = GlobalVariables.SpeedPractisingTime; break;
        }
        
        RectTransform rt = timerImageFG.GetComponent<RectTransform>();
        float totalToGrow = 200f;
        float duration = PracticingTimeLeft;
        float growthPerSecond = totalToGrow / duration;

        while (PracticingTimeLeft > 0)
        {
            yield return null;
            PracticingTimeLeft -= Time.deltaTime;
            GlobalVariables.CurrentPracticeTimerSliderValue += growthPerSecond * Time.deltaTime;
            
            if (!timerImageBG || !timerImageFG  || !rt)
            {
                timerImageBG = LoggedPracticeTimerImageBG;
                timerImageFG = LoggedPracticeTimerImageFG;
                if (timerImageFG) rt = timerImageFG.GetComponent<RectTransform>();
            }

            if (!timerImageBG || !timerImageFG || !rt) continue;

            if (GlobalVariables.IsPracticing && GlobalVariables.ActiveScene == "Desktop")
            {
                timerImageBG.SetActive(true);
                rt.sizeDelta = new Vector2(GlobalVariables.CurrentPracticeTimerSliderValue, 30);
            }
        }
        
        timerImageBG.SetActive(false);
        
        if (JobManager.Instance)
        {
            JobManager.Instance.RefreshUI();
        }
    }
}