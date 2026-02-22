using System;
using TMPro;
using UnityEngine;

public class PracticeFinished : MonoBehaviour
{
    public TextMeshProUGUI qualityMultiplierText;
    public TextMeshProUGUI speedMultiplierText;

    private void Awake()
    {
        PracticeCanvasManager.Instance.finishedCanvas = gameObject;
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        qualityMultiplierText.text = "Quality Multiplier: " + GlobalVariables.QualityMultiplier;
        speedMultiplierText.text = "Speed Multiplier: " + GlobalVariables.SpeedMultiplier;
        Debug.Log("Practice Finished");
        if (JobGenerator.Instance != null)
        { 
            JobGenerator.Instance.RefreshAllJobsUI();
        }
    }
}
