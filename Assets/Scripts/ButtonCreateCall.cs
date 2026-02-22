using UnityEngine;
using UnityEngine.UI;

public class ButtonCreateCall : MonoBehaviour
{
    public int practiceType;
    private void Awake()
    {
        switch (practiceType)
        {
            case 0: PracticeCanvasManager.Instance.qualityUpgradeButton = GetComponent<Button>(); PracticeCanvasManager.Instance.SetButtonListener(GetComponent<Button>(), practiceType); break;
            case 1: PracticeCanvasManager.Instance.speedUpgradeButton = GetComponent<Button>(); PracticeCanvasManager.Instance.SetButtonListener(GetComponent<Button>(), practiceType); break;
        }
    }
}
