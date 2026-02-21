using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonConstructionLevelIncrease : MonoBehaviour  
{  
    public TextMeshProUGUI buttonText;
    public TextMeshProUGUI levelText;
    public int roomType;

    private void Start()
    {
        levelText.text = roomType switch
        {
            0 => "Level " + (GlobalVariables.HallBgLevel + 1),
            1 => "Level " + (GlobalVariables.BedroomBgLevel + 1),
            _ => throw new ArgumentOutOfRangeException()
        };

        switch (roomType)
        {
            case 0: if (GlobalVariables.HallBgLevel == 2) { buttonText.text = "MAX"; } break;
            case 1: if (GlobalVariables.BedroomBgLevel == 2) { buttonText.text = "MAX"; } break;
        }

        GetComponent<Button>().onClick.AddListener(ConstructionLevelIncrease);
    }

    private void ConstructionLevelIncrease()  //0 - hall, 1 - bedroom
    {
        switch (roomType)
        {
            case 0:
            {
                GlobalVariables.HallBgLevel = Mathf.Clamp(++GlobalVariables.HallBgLevel, 0,2);
                levelText.text = "Level " + (GlobalVariables.HallBgLevel + 1);
                if (GlobalVariables.HallBgLevel == 2)
                {
                    buttonText.text = "MAX";
                }
                break;
            }
            case 1:
            {
                GlobalVariables.BedroomBgLevel = Mathf.Clamp(++GlobalVariables.BedroomBgLevel, 0,2);
                levelText.text = "Level " + (GlobalVariables.BedroomBgLevel + 1);
                if (GlobalVariables.BedroomBgLevel == 2)
                {
                    buttonText.text = "MAX";
                }
                break;
            }
        }
    }
}