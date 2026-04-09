using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BetHandler : MonoBehaviour
{
    public TextMeshProUGUI currentBetText;
    public Button lowerBetButton;
    public Button riseBetButton;
    public Button maxBetButton;

    private void Start()
    {
        currentBetText.text = GlobalVariables.CurrentBet.ToString();
        lowerBetButton.onClick.AddListener(LowerBet);
        riseBetButton.onClick.AddListener(RiseBet);
        maxBetButton.onClick.AddListener(MaxBet);
    }

    private void LowerBet()
    {
        if (GlobalVariables.CurrentBet - 10 < 0) return;
        GlobalVariables.CurrentBet -= 10;
        currentBetText.text = GlobalVariables.CurrentBet.ToString();
    }

    private void RiseBet()
    {
        if (GlobalVariables.CurrentBet + 10 > GlobalVariables.Money) return;
        GlobalVariables.CurrentBet += 10;
        currentBetText.text = GlobalVariables.CurrentBet.ToString();
    }

    private void MaxBet()
    {
        if (GlobalVariables.Money == 0)
        {
            currentBetText.text = "0";
            return;
        }
        GlobalVariables.CurrentBet = GlobalVariables.Money;
        currentBetText.text = GlobalVariables.CurrentBet.ToString();
    }
    
    
}
