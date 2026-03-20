using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActivateJob : MonoBehaviour
{
    private TextMeshProUGUI _buttonText;
    private void Start()
    {
        _buttonText = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        TimerManagerScript.JobFinished += UpdateButtonText;
    }

    private void OnDisable()
    {
        TimerManagerScript.JobFinished -= UpdateButtonText;
    }

    private void UpdateButtonText()
    {
        if (GlobalVariables.HasJob)
        {
            _buttonText.text = "Start Contract";
            _buttonText.GetComponent<TextMeshProUGUI>().color = Color.black;
        }
    }

    public void ActivateJobFun()
    {
        if (GlobalVariables.HasJob) return;
        _buttonText.text = "Ongoing job";
        _buttonText.GetComponent<TextMeshProUGUI>().color = Color.red;
        Destroy(GlobalVariables.JobGameObject);
        DisplayContractInfo.Instance.ClearJobInfo();
        JobManager.Instance.StartContract(GlobalVariables.CurrentJob.JobTime, GlobalVariables.CurrentJob.JobMoney, GlobalVariables.CurrentJob.JobXp);
    }
}
