using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipDisplayer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string buttonType;

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipManager.Instance.Show(buttonType);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager.Instance.Hide();
    }
}
