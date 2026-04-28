using System;
using UnityEngine;

public class BillManager : MonoBehaviour
{
    public GameObject ElectricityTimerSlider;
    public GameObject RentTimerSlider;

    private void Awake()
    {
        StartCoroutine(TimerManagerScript.ElectricityTimer(TimerManagerScript.ElectricityImage.GetComponent<RectTransform>()));
    }
}
