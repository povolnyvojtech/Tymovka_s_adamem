using System;
using TMPro;
using UnityEngine;

public class Desktop : MonoBehaviour
{
    public TextMeshProUGUI careerPath;

    private void Start()
    {
        if (GlobalVariables.CareerPath == "None") return;
        careerPath.text = GlobalVariables.CareerPath;
        Debug.Log(GlobalVariables.CareerPath);
    }
}
