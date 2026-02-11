using UnityEngine;

public class PC : MonoBehaviour
{
    public Canvas pcScreen;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            pcScreen.enabled = false;
        }    
    }
}
