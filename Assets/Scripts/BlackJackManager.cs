using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlackJackManager : MonoBehaviour
{
    public TextMeshProUGUI number1;
    public TextMeshProUGUI number2;
    public TextMeshProUGUI countDisplayer;
    public GameObject hasWonImage;
    public Button hitButton;
    public Button stayButton;
    public TextMeshProUGUI hasWonText;
    public TextMeshProUGUI wonMoneyText;
    private int _counter;
    private Dictionary<string, int> hodnotyKaret = new Dictionary<string, int>()
    {
        {"2", 2}, {"3", 3}, {"4", 4}, {"5", 5},
        {"6", 6}, {"7", 7}, {"8", 8}, {"9", 9}, {"10", 10},
        {"Jack", 11}, {"Queen", 12}, {"King", 13},
        {"Ace", 14}
    };

    public void GenerateRandomNumber()
    {
        if (GlobalVariables.CurrentBlackJackBet > GlobalVariables.Money)
        {
            Debug.Log("Not enough money");
            return;
        }
        
        List<string> cardNames = hodnotyKaret.Keys.ToList();
        int value = hodnotyKaret[cardNames[Random.Range(0, cardNames.Count)]];
        string finalValue = "";

        if (_counter + value > 21)
        {
            hasWonImage.SetActive(true);
            hasWonText.text = "You lost";
            wonMoneyText.text = "";
            StartCoroutine(HideHasWonText());
            GlobalVariables.CurrentBlackJackBet = 0;
            _counter = 0;
            countDisplayer.text = _counter.ToString();
            return;
        }
        
        if (_counter + value == 21)
        {
            hasWonImage.SetActive(true);
            hasWonText.text = "You won";
            wonMoneyText.text = (GlobalVariables.CurrentBlackJackBet * 2).ToString();
            StartCoroutine(HideHasWonText());
            GlobalVariables.CurrentBlackJackBet = 0;
            _counter = 0;
            countDisplayer.text = _counter.ToString();
            return;
        }

        if (value > 10)
        {
            switch (value)
            {
                case 11: finalValue = "J"; _counter += 10; break;
                case 12: finalValue = "Q"; _counter += 10; break;
                case 13: finalValue = "K"; _counter += 10; break;
                case 14: finalValue = "A"; _counter += 10; break;
            }
        }
        else
        {
            _counter += value;
            finalValue = value.ToString();
        }
        
        
        number1.text = finalValue;
        number2.text = finalValue;
        countDisplayer.text = _counter.ToString();
    }
    
    private IEnumerator HideHasWonText()
    {
        hitButton.interactable = false;
        stayButton.interactable = false;
        yield return new WaitForSeconds(2f);
        hasWonImage.SetActive(false);
        hitButton.interactable = true;
        stayButton.interactable = true;
    }
}
