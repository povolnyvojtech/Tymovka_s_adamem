using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TriggerScript : MonoBehaviour
{
    public GameObject interactionText;
    public string targetScene;
    public bool locked;
    

    private void Start()
    {
        targetScene ??= "none"; //dva otazníky znamenají, že pokud je vlevo null, přiřaď tomu to co je vlevo
        interactionText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && interactionText != null)
        {
            interactionText.SetActive(true);
        }
        else
        { 
            Debug.Log("Chybí text. Enter");
        }
            
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !locked && Input.GetKey(KeyCode.E) && targetScene != "none")
        {
            SceneManager.LoadScene(targetScene);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && interactionText != null)
        {
            interactionText.SetActive(false);
        }
        else
        { 
            Debug.Log("Chybí text.  Exit");
        }
    }
}