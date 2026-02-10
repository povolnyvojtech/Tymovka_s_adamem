using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = System.Object;

public class TriggerScript : MonoBehaviour
{
    
    public TextMeshProUGUI interactionText;
    public string targetScene;
    public bool locked;

    private void Start()
    {
        interactionText.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (interactionText != null)
            {
                interactionText.enabled = true;
            }
            else
            {
                Debug.Log("Chybí text.");
            }
            
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!locked && Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(targetScene);
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (interactionText != null)
            {
                interactionText.enabled = false;
            }
            else
            {
                Debug.Log("Chybí text.");
            }
        }
    }
}