using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering.Universal; 
public class LightManager : MonoBehaviour
{
    public Light2D globalLight;
    public Light2D playerLight;
    public static LightManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
    private void Start()
    {
        if (GlobalVariables.CurrentElectricityState)
        {
            TurnPowerOn();
        }
        else{
            TurnPowerOff();
        }
    }

    public void TurnPowerOff()
    {
        globalLight.intensity = 0.02f;
        playerLight.enabled = true;
        GlobalVariables.CurrentElectricityState = false;
    }

    public void TurnPowerOn()
    {
        GlobalVariables.CurrentElectricityState = true;
        if (GlobalVariables.HasPaidElectricity)
        {
            globalLight.intensity = 1f;
            playerLight.enabled = false;
            return;
        }
        globalLight.intensity = 1f;
        playerLight.enabled = false;
        HallTimerManager.Instance.StartCoroutine(HallTimerManager.Instance.ElectricityTimer(false));
    }
}
