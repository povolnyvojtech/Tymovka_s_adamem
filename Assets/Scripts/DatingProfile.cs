using System;
using TMPro;
using UnityEngine;

public class DatingProfile : MonoBehaviour
{
    public TextMeshProUGUI username;

    private void OnEnable()
    {
        username.text = "Username: " + GlobalVariables.DatingName + " " + GlobalVariables.DatingSurname;
    }
}
