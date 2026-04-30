using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerScript : MonoBehaviour
{
    public GameObject interactionButton;
    public GameObject lockedText;
    public string targetScene;
    public bool locked;
    public bool powerSwitch;
    public GameObject powerSwitchOff;
    public GameObject powerSwitchOn;
    
    private bool _isPlayerInRange;

    private void Start()
    {
        targetScene ??= "none";
        interactionButton.SetActive(false);
    }

    private void Update()
    {
        if (_isPlayerInRange && !locked && Input.GetKeyDown(KeyCode.E) && targetScene != "none")    
        {
            if (powerSwitch)
            {
                if(GlobalVariables.PowerSwitchState)
                {
                    powerSwitchOn.SetActive(true);
                    powerSwitchOff.SetActive(false);
                    LightManager.Instance.TurnPowerOff();
                    GlobalVariables.PowerSwitchState = false;
                    return;
                }
                powerSwitchOn.SetActive(false);
                powerSwitchOff.SetActive(true);
                LightManager.Instance.TurnPowerOn();
                GlobalVariables.PowerSwitchState = true;
                return;
            }
            SceneManager.LoadScene(targetScene);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!interactionButton) return;
        _isPlayerInRange = true; 

        if (locked)
        {
            lockedText.SetActive(true);
        }
        interactionButton.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!interactionButton) return;
        _isPlayerInRange = false;

        if (locked)
        {
            lockedText.SetActive(false);
        }
        interactionButton.SetActive(false);
    }
}