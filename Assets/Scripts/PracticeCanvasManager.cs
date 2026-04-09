using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PracticeCanvasManager : MonoBehaviour
{
    public Button qualityUpgradeButton;
    public TextMeshProUGUI qualityLevelText;
    public Button speedUpgradeButton;
    public TextMeshProUGUI speedLevelText;

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
        qualityLevelText.text = "Level " + (GlobalVariables.QualityLevel);
        speedLevelText.text = "Level " + (GlobalVariables.SpeedLevel);
    }

    private void OnEnable()
    {
        RefreshLevelText(qualityLevelText, 0);
        RefreshLevelText(speedLevelText, 1);
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
            case 0: levelText.text = "Level " + (GlobalVariables.QualityLevel);break;
            case 1: levelText.text = "Level " + (GlobalVariables.SpeedLevel); break;
        }
    }
    
    public void RefreshButtonText(Button button, int type)
    {
        Image imgComponent = button.GetComponent<Image>();
        switch (type)
        { 
            //TODO změnit akorát sprite
            case 0: /*imgComponent.sprite = ;*/ break;
            case 1: /*imgComponent.sprite = ;*/ break;
        }
    }
    
    private void RaiseQualityMultiplier()
    {
        if (GlobalVariables.IsPracticing || GlobalVariables.QualityLevel == 10) return;
        GlobalVariables.IsPracticing = true;
        GlobalVariables.CurrentPracticingType = 0;
        StartCoroutine(TimerManagerScript.PracticingTimer(0));
        StartCoroutine(QualityPractisingTimer());
    }
    
    private void RaiseSpeedMultiplier()
    {
        if (GlobalVariables.IsPracticing || GlobalVariables.SpeedLevel== 10) return;
        GlobalVariables.IsPracticing = true;
        GlobalVariables.CurrentPracticingType = 1;
        StartCoroutine(TimerManagerScript.PracticingTimer(1));
        StartCoroutine(SpeedPractisingTimer());
    }
    
    private IEnumerator QualityPractisingTimer()
    {
        yield return new WaitForSeconds(GlobalVariables.QualityPractisingTime);
        GlobalVariables.QualityLevel += 1;
        RefreshLevelText(qualityLevelText, 0);
        GlobalVariables.CurrentPracticingType = 2;
        
        //TODO qualityLevelText je null protože corutina, to se vztahuje i na qualityButtonText - z nějakýho důvodu to funguje
        if (GlobalVariables.ActiveScene == "Desktop" && qualityLevelText)
        {
            qualityLevelText.text = "Level " + (GlobalVariables.QualityLevel);
            RefreshButtonText(qualityUpgradeButton, 0);
        }
        
        GlobalVariables.QualityMultiplier += 0.1f;
        --GlobalVariables.QualityPractisingTime;
        GlobalVariables.IsPracticing = false;
        if (finishedCanvas)
        {
            finishedCanvas.SetActive(true);
        }
        
    }

    private IEnumerator SpeedPractisingTimer(){
        yield return new WaitForSeconds(GlobalVariables.SpeedPractisingTime);
        GlobalVariables.SpeedLevel += 1;
        RefreshLevelText(speedLevelText, 1);
        GlobalVariables.CurrentPracticingType = 2;
        speedLevelText.text = "Level " + (GlobalVariables.SpeedLevel);
        RefreshButtonText(speedUpgradeButton, 1);
        if ((GlobalVariables.SpeedMultiplier -= 0.07f) > 0) GlobalVariables.SpeedMultiplier -= 0.07f;
        --GlobalVariables.SpeedPractisingTime;
        if (finishedCanvas)
        {
            finishedCanvas.SetActive(true);
        }
    }
}
