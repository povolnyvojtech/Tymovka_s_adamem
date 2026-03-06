using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TooltipDisplayer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string buttonStatsText;
    public TextMeshProUGUI buttonText;
    public int buttonType; //gym, vzhled, invest money, rizz ..... TODO dodělat další vlastnosti
    public float value;
    private int _state = 0; //0 - zamceny, 1 - nesplněný, 2 - hotový
    public bool firstButton;
    public bool lastButton;
    public TooltipDisplayer previousButton;
    public TooltipDisplayer nextButton;

    private void Start()
    {
        if (firstButton)
        {
            _state = 1;
        }
        ChangeText();
    }
    
    public void UnlockNext()
    {
        if (previousButton == null || previousButton._state != 2) return;
        if (lastButton && _state != 2)
        {
            _state = 1;
            ChangeText();
            return;
        }
        _state = nextButton._state != 0 ? 2 : 1;
        ChangeText();
    }
    
    public void ChangeState()
    {
        if ((previousButton == null || previousButton._state != 2) && !firstButton ) return;
        if (firstButton)
        {   
            _state = Math.Clamp(++_state, 0, 2);
            ChangeText();    
        }
        _state = Math.Clamp(++_state, 0, 2);
        ChangeText();
    }

    private void ChangeText()
    {
        buttonText.text = _state switch
        {
            0 => "Locked",
            1 => "Do",
            2 => "Done",
            _ => "failed"
        };
    }
    public void UpgradeSkill()
    {
        if (_state == 0) return;
        switch (buttonType) //zatím 0 - gym = float od 0 do 100 TODO reprezentace v baru, 1 - vzhled TODO nějakou globální proměnnou pro vzhled
        {
            case 0:
            {
                GlobalVariables.GymLevel += value;
                GlobalVariables.CalculateChanceToGetGirls();
                break;
            }
            case 1:
            {
                GlobalVariables.OverallLook += value;
                GlobalVariables.CalculateChanceToGetGirls();
                break;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_state == 0) return;
        TooltipManager.Instance.Show(buttonStatsText);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_state == 0) return;
        TooltipManager.Instance.Hide();
    }
}
