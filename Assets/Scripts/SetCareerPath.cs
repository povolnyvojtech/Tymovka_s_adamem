using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetCareerPath : MonoBehaviour
{
    public void SetCareerPathFunc(string careerPath)
    {
        GlobalVariables.CareerPath = careerPath;
        Debug.Log(careerPath);
        SceneManager.LoadScene("Desktop");
    }
}