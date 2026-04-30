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
        if (GlobalVariables.HasPaidElectricity)
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
    }

    public void TurnPowerOn()
    {
        globalLight.intensity = 1f;
        playerLight.enabled = false;
        if (!GlobalVariables.HasPaidElectricity)
        {
            TimerManagerScript.Instance.StartCoroutine(TimerManagerScript.ElectricityTimer(false));
        }
    }
}
