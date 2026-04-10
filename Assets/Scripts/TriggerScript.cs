using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerScript : MonoBehaviour
{
    public GameObject interactionButton;
    public GameObject lockedText;
    public string targetScene;
    public bool locked;
    
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
            SceneManager.LoadScene(targetScene);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && interactionButton != null)
        {
            _isPlayerInRange = true; 

            if (locked)
            {
                lockedText.SetActive(true);
            }
            interactionButton.SetActive(true);
        }
        else if (interactionButton == null && other.CompareTag("Player"))
        { 
            Debug.Log("Chybí interactionButton. Enter");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || interactionButton == null) return;
        _isPlayerInRange = false;

        if (locked)
        {
            lockedText.SetActive(false);
        }
        interactionButton.SetActive(false);
    }
}