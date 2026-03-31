using UnityEngine;
using UnityEngine.UI;

public class ShowExitPage : MonoBehaviour
{
    public GameObject exitPanel;
    private bool _state;
    
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowHideExitPanel);
    }

    private void ShowHideExitPanel()
    {
        _state = !_state;
        exitPanel.SetActive(_state);
    }
}
