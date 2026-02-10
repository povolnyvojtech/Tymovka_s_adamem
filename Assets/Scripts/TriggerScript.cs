using System;
using TMPro;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    
    public TextMeshProUGUI interactionText;

    private void Start()
    {
        interactionText.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hráč vstoupil do zóny!");
            interactionText.enabled = true;
            
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hráč opustil zónu.");
            interactionText.enabled = false;
        }
    }
}