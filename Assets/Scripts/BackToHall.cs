using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToHall : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Hall");
        }
    }
}
