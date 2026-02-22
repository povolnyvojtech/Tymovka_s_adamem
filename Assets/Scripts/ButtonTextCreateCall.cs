using TMPro;
using UnityEngine;

public class ButtonTextCreateCall : MonoBehaviour
{
    public int practiceType;
    private void Awake()
    {
        switch (practiceType)
        {
            case 0: PracticeCanvasManager.Instance.qualityButtonText = GetComponent<TextMeshProUGUI>(); break;
            case 1: PracticeCanvasManager.Instance.speedButtonText = GetComponent<TextMeshProUGUI>(); break;
        }
    }
}
