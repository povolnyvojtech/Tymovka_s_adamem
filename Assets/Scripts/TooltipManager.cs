using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class TooltipManager : MonoBehaviour
{
    public Canvas canvas;
    public Transform tooltipTransform;
    public static TooltipManager Instance;
    public TextMeshProUGUI statsText;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!tooltipTransform.gameObject.activeSelf) return;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera, out var mousePos
        );

        tooltipTransform.localPosition = mousePos;
    }

    public void Show(string buttonType)
    {
        statsText.text = buttonType;
        tooltipTransform.gameObject.SetActive(true);
    }
    
    public void Hide()
    {
        tooltipTransform.gameObject.SetActive(false);
    }
}
