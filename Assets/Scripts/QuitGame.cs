using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void ExitToDesktop()
    {
        Application.Quit();
        
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
