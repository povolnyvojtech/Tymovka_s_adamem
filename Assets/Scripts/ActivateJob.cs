using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActivateJob : MonoBehaviour
{
    public TextMeshProUGUI buttonText;
    
    private void UpdateButtonText()
    {
        if (!GlobalVariables.HasJob)
        {
            buttonText.text = "Start Contract";
            buttonText.GetComponent<TextMeshProUGUI>().color = Color.black;
        }
    }
    
    private void OnEnable()
    {
        TimerManagerScript.JobFinished += UpdateButtonText;
    }

    private void OnDisable()
    {
        TimerManagerScript.JobFinished -= UpdateButtonText;
    }

    public void ActivateJobFun()
    {
        if (GlobalVariables.HasJob) return;
        buttonText.text = "Ongoing job";
        buttonText.GetComponent<TextMeshProUGUI>().color = Color.red;
        Destroy(GlobalVariables.JobGameObject);
        DisplayContractInfo.Instance.ClearJobInfo();
        JobManager.Instance.StartContract(GlobalVariables.CurrentJob.JobTime, GlobalVariables.CurrentJob.JobMoney, GlobalVariables.CurrentJob.JobXp);
    }
}
