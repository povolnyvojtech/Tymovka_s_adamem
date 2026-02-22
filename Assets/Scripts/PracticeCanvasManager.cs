using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PracticeCanvasManager : MonoBehaviour
{
    public Button qualityUpgradeButton;
    public TextMeshProUGUI qualityLevelText;
    public TextMeshProUGUI qualityButtonText;
    public Button speedUpgradeButton;
    public TextMeshProUGUI speedLevelText;
    public TextMeshProUGUI speedButtonText;

    public GameObject finishedCanvas;
    public static PracticeCanvasManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        qualityUpgradeButton.onClick.AddListener((RaiseQualityMultiplier));
        speedUpgradeButton.onClick.AddListener((RaiseSpeedMultiplier));
    }
    
    private void Start()
    {
        qualityLevelText.text = "Level " + (GlobalVariables.QualityLevel + 1);
        speedLevelText.text = "Level " + (GlobalVariables.SpeedLevel + 1);
    }

    public void SetButtonListener(Button button, int type)
    {
        switch (type)
        {
            case 0: button.onClick.AddListener((RaiseQualityMultiplier)); break;
            case 1: button.onClick.AddListener((RaiseSpeedMultiplier)); break;
        }
    }

    public void RefreshLevelText(TextMeshProUGUI levelText, int type)
    {
        switch (type)
        {
            case 0: levelText.text = "Level " + (GlobalVariables.QualityLevel + 1); break;
            case 1: levelText.text = "Level " + (GlobalVariables.SpeedLevel + 1); break;
        }
    }
    
    private void RaiseQualityMultiplier()
    {
        if (GlobalVariables.IsPracticing) return;
        GlobalVariables.IsPracticing = true;
        CheckPracticeLevel();
        StartCoroutine(QualityPractisingTimer());
    }
    
    private void RaiseSpeedMultiplier()
    {
        if (GlobalVariables.IsPracticing) return;
        GlobalVariables.IsPracticing = true;
        CheckPracticeLevel();
        StartCoroutine(SpeedPractisingTimer());
    }
    
    private IEnumerator QualityPractisingTimer()
    {
        yield return new WaitForSeconds(GlobalVariables.QualityPractisingTime);
        qualityLevelText.text = "Level " + (++GlobalVariables.QualityLevel + 1);
        GlobalVariables.QualityMultiplier += 0.1f;
        --GlobalVariables.QualityPractisingTime;
        GlobalVariables.IsPracticing = false;
        finishedCanvas.SetActive(true);
        
    }

    private IEnumerator SpeedPractisingTimer(){
        yield return new WaitForSeconds(GlobalVariables.SpeedPractisingTime);
        speedLevelText.text = "Level " + (++GlobalVariables.SpeedLevel + 1);
        if ((GlobalVariables.SpeedMultiplier -= 0.07f) > 0) GlobalVariables.SpeedMultiplier -= 0.07f;
        --GlobalVariables.SpeedPractisingTime;
        finishedCanvas.SetActive(true);
    }

    private void CheckPracticeLevel()
    {
        if (GlobalVariables.QualityLevel == 10)
        {
            qualityButtonText.text = "MAX";
        }
        if (GlobalVariables.SpeedLevel == 10)
        {
            speedButtonText.text = "MAX";
        }
    }
}
