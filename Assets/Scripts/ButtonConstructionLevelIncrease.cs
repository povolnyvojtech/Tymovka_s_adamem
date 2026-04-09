using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonConstructionLevelIncrease : MonoBehaviour  
{  
    public TextMeshProUGUI buttonText;
    public TextMeshProUGUI costText;
    public GameObject notEnoughMoneyText;
    public int roomType;

    private void Start()
    {
        costText.text = roomType switch
        {
            0 => "Cost " + (GlobalVariables.CurrentHallBgUpgradeCost),
            1 => "Cost " + (GlobalVariables.CurrentBedroomBgUpgradeCost),
            _ => throw new ArgumentOutOfRangeException()
        };

        switch (roomType)
        {
            case 0: if (GlobalVariables.HallBgLevel == 2) { buttonText.text = "MAX"; } break;
            case 1: if (GlobalVariables.BedroomBgLevel == 2) { buttonText.text = "MAX"; } break;
        }

        GetComponent<Button>().onClick.AddListener(ConstructionLevelIncrease);
    }

    private void OnEnable()
    {
        notEnoughMoneyText.SetActive(false);
    }

    private void ConstructionLevelIncrease()  //0 - hall, 1 - bedroom
    {
        switch (roomType)
        {
            case 0:
            {
                if (CheckPurchase())
                {
                    StartCoroutine(DisableNotEnoughMoneyTimer());
                    return;
                }
                GlobalVariables.HallBgLevel = Mathf.Clamp(++GlobalVariables.HallBgLevel, 0,2);
                GlobalVariables.CurrentHallBgUpgradeCost += 1500;
                costText.text = "Cost " + (GlobalVariables.CurrentHallBgUpgradeCost);
                if (GlobalVariables.HallBgLevel == 2)
                {
                    buttonText.text = "MAX";
                }
                break;
            }
            case 1:
            {
                if (CheckPurchase())
                {
                    StartCoroutine(DisableNotEnoughMoneyTimer());
                    return;
                }
                GlobalVariables.BedroomBgLevel = Mathf.Clamp(++GlobalVariables.BedroomBgLevel, 0,2);
                GlobalVariables.CurrentBedroomBgUpgradeCost += 1300;
                costText.text = "Cost " + (GlobalVariables.CurrentBedroomBgUpgradeCost);
                if (GlobalVariables.BedroomBgLevel == 2)
                {
                    buttonText.text = "MAX";
                }
                break;
            }
        }
    }

    private bool CheckPurchase()
    {
        switch (roomType)
        {
            case 0: return (GlobalVariables.CurrentHallBgUpgradeCost > GlobalVariables.Money);
            case 1: return (GlobalVariables.CurrentBedroomBgUpgradeCost > GlobalVariables.Money);
            default: return false;
        }
    }
    
    private IEnumerator DisableNotEnoughMoneyTimer()
    {
        notEnoughMoneyText.SetActive(true);
        yield return new WaitForSeconds(2);
        notEnoughMoneyText.SetActive(false);
    }
}