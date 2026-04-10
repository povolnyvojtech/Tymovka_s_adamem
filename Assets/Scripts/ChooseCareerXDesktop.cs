using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SwitchChooseXDesktop : MonoBehaviour
{
    public GameObject interactionButton;
    private string _targetScene;
    
    private bool _isPlayerInRange;
    

    private void Start()
    {
        _targetScene ??= "none"; //dva otazníky znamenají, že pokud je vlevo null, přiřaď tomu to co je vlevo
        interactionButton.SetActive(false);
    }

    private void Update()
    {
        if (_isPlayerInRange && Input.GetKeyDown(KeyCode.E) && _targetScene != "none")
        {
            SceneManager.LoadScene(_targetScene);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || !interactionButton) return;
        _targetScene = GlobalVariables.HasCareer ? "Desktop" : "PcChoosePath";
        interactionButton.SetActive(true);
        _isPlayerInRange = true;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && interactionButton != null)
        {
            interactionButton.SetActive(false);
            _isPlayerInRange = false;
        }
    }
}