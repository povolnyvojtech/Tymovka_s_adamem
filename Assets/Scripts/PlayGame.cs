using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public void StartPlaying()
    {
        SceneManager.LoadScene("Hall");
    }
}
