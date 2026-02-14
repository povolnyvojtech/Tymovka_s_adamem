using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToHall : MonoBehaviour
{
    public string targetScene;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(targetScene);
        }
    }
}
