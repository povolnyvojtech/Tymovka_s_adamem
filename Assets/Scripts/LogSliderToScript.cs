using System;
using UnityEngine;
using UnityEngine.UI;

public class LogSliderToScript : MonoBehaviour
{
    public GameObject currentJobTimerSliderBG;
    public Image currentJobTimerSliderFG;
    public GameObject practiceTimerSliderBG;
    public Image practiceTimerSliderFG;
    
    private void Awake()
    {
        TimerManagerScript.LoggedJobTimerImageBG = currentJobTimerSliderBG;
        TimerManagerScript.LoggedJobTimerImageFG = currentJobTimerSliderFG;
        TimerManagerScript.TemporaryJobRt = currentJobTimerSliderFG.GetComponent<RectTransform>();
        TimerManagerScript.LoggedPracticeTimerImageBG = practiceTimerSliderBG;
        TimerManagerScript.LoggedPracticeTimerImageFG = practiceTimerSliderFG;
        TimerManagerScript.TemporaryPracticeRt = practiceTimerSliderFG.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (!TimerManagerScript.LoggedJobTimerImageBG || !TimerManagerScript.LoggedJobTimerImageFG ||
            !TimerManagerScript.LoggedPracticeTimerImageBG || !TimerManagerScript.LoggedPracticeTimerImageFG)
        {
            TimerManagerScript.LoggedJobTimerImageBG = currentJobTimerSliderBG;
            TimerManagerScript.LoggedJobTimerImageFG = currentJobTimerSliderFG;
            TimerManagerScript.TemporaryJobRt = currentJobTimerSliderFG.GetComponent<RectTransform>();
            TimerManagerScript.LoggedPracticeTimerImageBG = practiceTimerSliderBG;
            TimerManagerScript.LoggedPracticeTimerImageFG = practiceTimerSliderFG;
            TimerManagerScript.TemporaryPracticeRt = practiceTimerSliderFG.GetComponent<RectTransform>();
        }
    }
}
