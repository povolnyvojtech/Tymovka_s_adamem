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
        TimerManagerScript.JobTimerImageBg = currentJobTimerSliderBG;
        TimerManagerScript.JobTimerImageFg = currentJobTimerSliderFG;
        TimerManagerScript.JobRt = currentJobTimerSliderFG.GetComponent<RectTransform>();
        TimerManagerScript.PracticeTimerImageBg = practiceTimerSliderBG;
        TimerManagerScript.PracticeTimerImageFg = practiceTimerSliderFG;
        TimerManagerScript.PracticeRt = practiceTimerSliderFG.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (!TimerManagerScript.JobTimerImageBg || !TimerManagerScript.JobTimerImageFg ||
            !TimerManagerScript.PracticeTimerImageBg || !TimerManagerScript.PracticeTimerImageFg)
        {
            TimerManagerScript.JobTimerImageBg = currentJobTimerSliderBG;
            TimerManagerScript.JobTimerImageFg = currentJobTimerSliderFG;
            TimerManagerScript.JobRt = currentJobTimerSliderFG.GetComponent<RectTransform>();
            TimerManagerScript.PracticeTimerImageBg = practiceTimerSliderBG;
            TimerManagerScript.PracticeTimerImageFg = practiceTimerSliderFG;
            TimerManagerScript.PracticeRt = practiceTimerSliderFG.GetComponent<RectTransform>();
        }
    }
}
