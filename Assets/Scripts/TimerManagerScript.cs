using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimerManagerScript : MonoBehaviour
{
    public static TimerManagerScript Instance {get; private set;}
    private const float RefreshInterval = 20f;
    public static float JobOffersTimeLeft;
    public static float CurrentJobTimeLeft;
    public static float PracticingTimeLeft;
    public static GameObject JobTimerImageBg;
    public static Image JobTimerImageFg;
    public static RectTransform JobRt;
    public static GameObject PracticeTimerImageBg;
    public static Image PracticeTimerImageFg;
    public static RectTransform PracticeRt;
    
    
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
        Debug.Log("0");
        Debug.Log(JobTimerImageBg);
        JobTimerImageBg.SetActive(true);
        Debug.Log("1");
        float totalToGrow = 200f;
        float duration = jobTime;
        float growthPerSecond = totalToGrow / duration;
        CurrentJobTimeLeft = jobTime * GlobalVariables.SpeedMultiplier;
        
        Debug.Log("2");
        Debug.Log(CurrentJobTimeLeft);
        while (CurrentJobTimeLeft > 0)
        {
            Debug.Log("3");
            yield return null;
            CurrentJobTimeLeft -= Time.deltaTime;
            Debug.Log("4");
            GlobalVariables.CurrentJobTimerSliderValue += growthPerSecond * Time.deltaTime;

            Debug.Log("5");
            if (!JobTimerImageBg || !JobTimerImageFg || !JobRt) continue;
            
            if (GlobalVariables.HasJob && GlobalVariables.ActiveScene == "Desktop")
            {
                Debug.Log("6");
                JobTimerImageBg.SetActive(true);
                Debug.Log("7");
                JobRt.sizeDelta = new Vector2(GlobalVariables.CurrentJobTimerSliderValue, 30);
            }
        }
        
        GlobalVariables.HasJob = false;
        Debug.Log("8");
        JobFinished?.Invoke();
        Debug.Log("9");
        JobTimerImageBg.SetActive(false);
        GlobalVariables.CurrentJobTimerSliderValue = 0;
        GlobalVariables.Money += (int)Mathf.Round(jobMoney * GlobalVariables.QualityMultiplier);
        GlobalVariables.Xp += jobXp;
        GlobalVariables.LevelUp();
        
        Debug.Log("10");
        if (JobManager.Instance)
        {
            Debug.Log("11");
            JobManager.Instance.RefreshUI();
            Debug.Log("12");
        }
    }

    public static IEnumerator PracticingTimer(int practiceType) //0 - quality, 1 - speed
    {
        PracticeTimerImageBg.SetActive(true);
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

            if (!PracticeTimerImageBg || !PracticeTimerImageFg || !PracticeRt) continue;

            if (GlobalVariables.IsPracticing && GlobalVariables.ActiveScene == "Desktop")
            {
                PracticeTimerImageBg.SetActive(true);
                PracticeRt.sizeDelta = new Vector2(GlobalVariables.CurrentPracticeTimerSliderValue, 30);
            }
        }
        
        PracticeTimerImageBg.SetActive(false);
        GlobalVariables.CurrentPracticeTimerSliderValue = 0;
        
        if (JobManager.Instance)
        {
            JobManager.Instance.RefreshUI();
        }
    }

    public static IEnumerator InboxMessageDestroyTimer(Transform inboxContent)
    {
        yield return new WaitForSeconds(2f);
        foreach (Transform message in inboxContent)
        {
            Destroy(message.gameObject);
        }
    }
}