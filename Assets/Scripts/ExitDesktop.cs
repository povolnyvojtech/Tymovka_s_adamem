using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDesktop : MonoBehaviour
{
    public void ExitDesktopFunction()
    {
        SceneManager.LoadScene("Bedroom");
    }
}
