using UnityEngine;

public class ActivateJob : MonoBehaviour
{
    public void ActivateJobFun()
    {
        if (GlobalVariables.HasJob) return;
        Destroy(GlobalVariables.JobGameObject);
        DisplayContractInfo.Instance.ClearJobInfo();
        JobManager.Instance.StartContract(GlobalVariables.CurrentJob.JobTime, GlobalVariables.CurrentJob.JobMoney, GlobalVariables.CurrentJob.JobXp);
    }
}
