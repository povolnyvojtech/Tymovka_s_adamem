using System;
using TMPro;
using UnityEngine;

public class ShowPC : MonoBehaviour
{
    public Canvas pcScreen;
    public TextMeshProUGUI interactionText;

    private void Start()
    {
        interactionText.enabled = false;
        pcScreen.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && interactionText != null)
        {
            interactionText.enabled = true;
        }
        else
        {
            Debug.Log("Chybí text nebo nejsi player.");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            pcScreen.enabled = true;
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
