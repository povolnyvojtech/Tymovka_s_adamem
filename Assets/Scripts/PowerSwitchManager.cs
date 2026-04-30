using System;
using UnityEngine;

public class PowerSwitchManager : MonoBehaviour
{
    public GameObject powerSwitchOn;
    public GameObject powerSwitchOff;

    private void Start()
    {
        if (GlobalVariables.HasPaidElectricity)
        {
            powerSwitchOn.SetActive(true);
            powerSwitchOff.SetActive(false);
            return;
        }
        powerSwitchOn.SetActive(false);
        powerSwitchOff.SetActive(true);
    }
}
