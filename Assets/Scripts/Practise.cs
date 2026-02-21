using System;using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Practise : MonoBehaviour
{
    public int practiceType; //0 - quality, 1 - speed
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI buttonText;
    public GameObject practiseFinishedCanvas;
    private CanvasGroup canvasGroup;
    private bool _currentUiState;

    private static GameObject _instance;
    
    private void Awake()
    {
        GameObject rootCanvas = gameObject.transform.root.gameObject;
        canvasGroup = GetComponentInParent<CanvasGroup>();
        if (_instance != null && _instance != rootCanvas)
        {
            Destroy(rootCanvas);
            return;
        }
        _instance = rootCanvas;
        DontDestroyOnLoad(rootCanvas);
    }
    
    private void Start()
    {
        if (_instance != null && _instance != gameObject.transform.root.gameObject) return;
        
        levelText.text = practiceType switch
        {
            0 => "Level " + (GlobalVariables.QualityLevel + 1),
            1 => "Level " + (GlobalVariables.SpeedLevel + 1),
            _ => throw new ArgumentOutOfRangeException()
        };

        switch (practiceType)
        {
            case 0: if (GlobalVariables.HallBgLevel == 10) { buttonText.text = "MAX"; } break;
            case 1: if (GlobalVariables.BedroomBgLevel == 10) { buttonText.text = "MAX"; } break;
        }
        
        
        GetComponent<Button>().onClick.AddListener(RaiseMultiplier);
    }
    
    public void UIVisibilityManager()
    {
        //TODO bug s otviraním practise canvasu
        _currentUiState = !_currentUiState;
        if (_currentUiState)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }

    private void RaiseMultiplier()
    {
        if (GlobalVariables.IsPracticing) return;
        GlobalVariables.IsPracticing = true;
        StartCoroutine(PractisingTimer());
    }

    private IEnumerator PractisingTimer()
    {
        switch (practiceType)
        {
            case 0:
            {
                yield return new WaitForSeconds(GlobalVariables.QualityPractisingTime);
                GlobalVariables.QualityMultiplier += 0.1f;
                --GlobalVariables.QualityPractisingTime;
                break;
            }
            case 1:
            {
                yield return new WaitForSeconds(GlobalVariables.SpeedPractisingTime);
                if ((GlobalVariables.SpeedMultiplier -= 0.07f) > 0) GlobalVariables.SpeedMultiplier -= 0.07f;
                --GlobalVariables.SpeedPractisingTime;
                break;
            }
        }
        GlobalVariables.IsPracticing = false;
        if (!practiseFinishedCanvas)
        {
            yield return null;
        }
        else
        {
            practiseFinishedCanvas.SetActive(true);
        }
    }
}
