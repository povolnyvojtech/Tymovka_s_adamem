using UnityEngine;

public class ActivateJob : MonoBehaviour
{
    public void ActivateJobFun()
    {
        Debug.Log(GlobalVariables.JobGameObject);
        Destroy(GlobalVariables.JobGameObject);
        JobManager.Instance.StartContract(GlobalVariables.CurrentJob.JobTime, GlobalVariables.CurrentJob.JobMoney, GlobalVariables.CurrentJob.JobXp);
    }
}
