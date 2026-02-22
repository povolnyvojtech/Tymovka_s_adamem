using TMPro;
using UnityEngine;

public class LevelTextCreateCall : MonoBehaviour
{
    public int practiceType;
    private void Awake()
    {
        switch (practiceType)
        {
            case 0: PracticeCanvasManager.Instance.qualityLevelText = GetComponent<TextMeshProUGUI>();
                PracticeCanvasManager.Instance.RefreshLevelText(GetComponent<TextMeshProUGUI>(), practiceType); break;
            case 1: PracticeCanvasManager.Instance.speedLevelText = GetComponent<TextMeshProUGUI>();
                PracticeCanvasManager.Instance.RefreshLevelText(GetComponent<TextMeshProUGUI>(), practiceType); break;
        }
    }
}
