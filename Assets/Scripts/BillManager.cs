using System;
using TMPro;
using UnityEngine;

public class BillManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    public void RestartElectricityCoroutine()
    {
        if (GlobalVariables.Money - 200 < 0) return;
        StopCoroutine(GlobalVariables.ElectricityCoroutine);
        GlobalVariables.CurrentElectricitySliderValue = 0;
        GlobalVariables.ElectricityDuration += 5f;
        GlobalVariables.Money -= 200;
        moneyText.text = GlobalVariables.Money.ToString();
        GlobalVariables.ElectricityCoroutine = StartCoroutine(TimerManagerScript.ElectricityTimer(true));
    }
}
