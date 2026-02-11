using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = System.Object;

public class TriggerScript : MonoBehaviour
{

    public enum InteractionType {Pc, Other};
    public InteractionType currentType;
    
    public Canvas pcScreen;
    
    public TextMeshProUGUI interactionText;
    public string targetScene;
    public bool locked;
    

    private void Start()
    {
        if (pcScreen != null)
        {
            pcScreen.enabled = false;
        }

        if (targetScene == null)
        {
            targetScene = "none";
        }
        interactionText.enabled = false;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && interactionText != null)
        {
            interactionText.enabled = true;
        }
        else
        { 
            Debug.Log("Chybí text. Enter");
        }
            
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && currentType == InteractionType.Other && !locked && Input.GetKey(KeyCode.E) && targetScene != "none")
        {
            SceneManager.LoadScene(targetScene);
        }
        else if (other.CompareTag("Player") && currentType == InteractionType.Pc && Input.GetKey(KeyCode.E))
        {
            pcScreen.enabled = true;
        }
        else
        {
            Debug.Log("neco je null ig");
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && interactionText != null)
        {
            if(InteractionType.Pc == currentType){
                pcScreen.enabled = false;
            }
            interactionText.enabled = false;
        }
        else
        { 
            Debug.Log("Chybí text.  Exit");
        }
    }
}