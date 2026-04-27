using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlackJackManager : MonoBehaviour
{
    public TextMeshProUGUI playerNumber1;
    public TextMeshProUGUI playerNumber2;
    public TextMeshProUGUI dealerNumber1;
    public TextMeshProUGUI dealerNumber2;
    public TextMeshProUGUI playerCountDisplayer;
    public TextMeshProUGUI playerDealtCardsDisplayer;
    public TextMeshProUGUI dealerCountDisplayer;
    public TextMeshProUGUI dealerDealtCardsDisplayer;
    public GameObject hasWonImage;
    public Button hitButton;
    public Button stayButton;
    public Button startGameButton;
    public TextMeshProUGUI hasWonText;
    public TextMeshProUGUI wonMoneyText;
    public GameObject notEnoughMoneyText;
    public TextMeshProUGUI globalMoneyText;
    private int _playerCounter;
    private int _dealerCounter;
    private readonly Dictionary<string, int> _cardsValue = new Dictionary<string, int>()
    {
        {"2", 2}, {"3", 3}, {"4", 4}, {"5", 5},
        {"6", 6}, {"7", 7}, {"8", 8}, {"9", 9}, {"10", 10},
        {"Jack", 11}, {"Queen", 12}, {"King", 13},
        {"Ace", 14}
    };
    private List<int> _playerDealtCards = new List<int>();
    private List<int> _dealerDealtCards = new List<int>();

    private bool PrepareForNewRound()
    {
        _playerDealtCards.Clear();
        _dealerDealtCards.Clear();
        playerDealtCardsDisplayer.text = "";
        dealerDealtCardsDisplayer.text = "";
        playerCountDisplayer.text = "0";
        dealerCountDisplayer.text = "0";
        startGameButton.gameObject.SetActive(true);
        hitButton.gameObject.SetActive(false);
        stayButton.gameObject.SetActive(false);
        return true;
    }

    public void StartGame()
    {
        GlobalVariables.Money -= GlobalVariables.CurrentBlackJackBet;
        globalMoneyText.text =  GlobalVariables.Money.ToString();
        startGameButton.gameObject.SetActive(false);
        hitButton.gameObject.SetActive(true);
        stayButton.gameObject.SetActive(true);
        StartCoroutine(DealCards());
    }

    private IEnumerator DealCards()
    {
        if (GlobalVariables.CurrentBlackJackBet > GlobalVariables.Money)
        {
            notEnoughMoneyText.SetActive(true);
            StartCoroutine(HideText(false));
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        hitButton.interactable = false;
        stayButton.interactable = false;
        
        List<string> cardNames = _cardsValue.Keys.ToList();
        string dealtCardsString = "";
        
        //deal to player
        for (int i = 0; i < 2; i++)
        {
            int value = _cardsValue[cardNames[Random.Range(0, cardNames.Count)]];
            _playerCounter += value;
            playerNumber1.text = value.ToString();
            playerNumber2.text = value.ToString();
            _playerDealtCards.Add(value);
            for (int j = 0; j < _playerDealtCards.Count; j++)
            {
                if (j == 0)
                {
                    dealtCardsString += _playerDealtCards[j].ToString();
                }
                else
                {
                    dealtCardsString += " + " + _playerDealtCards[j];
                }
            }
            playerCountDisplayer.text = _playerCounter.ToString();
            playerDealtCardsDisplayer.text = dealtCardsString;
            dealtCardsString = "";
            
            

            yield return new WaitForSeconds(1f);
        }
        
        //deal to dealer
        for (int i = 0; i < 2; i++)
        {
            int value = _cardsValue[cardNames[Random.Range(0, cardNames.Count)]];
            _dealerCounter += value;
            _dealerDealtCards.Add(value);
            for (int j = 0; j < _dealerDealtCards.Count; j++)
            {
                if (j == 0)
                {
                    dealtCardsString += _dealerDealtCards[j].ToString();
                    dealerNumber1.text = value.ToString();
                    dealerNumber2.text = value.ToString();
                }
                else
                {
                    dealerNumber1.text = "?";
                    dealerNumber2.text = "?";
                    dealtCardsString += " + ?";
                }
            }
            dealerCountDisplayer.text = _dealerDealtCards[0].ToString();
            dealerDealtCardsDisplayer.text = dealtCardsString;
            dealtCardsString = "";

            Check();
            yield return new WaitForSeconds(1f);
        }
        hitButton.interactable = true;
        stayButton.interactable = true;
        
    }

    public void Hit()
    {
        hitButton.interactable = false;
        stayButton.interactable = false;
        string dealtCardsString = "";
        List<string> cardNames = _cardsValue.Keys.ToList();
        int value = _cardsValue[cardNames[Random.Range(0, cardNames.Count)]];
        string finalValue = "";
        _playerDealtCards.Add(value);
        
        if (value > 10)
        {
            switch (value)
            {
                case 11: finalValue = "J"; _playerCounter += 10; break;
                case 12: finalValue = "Q"; _playerCounter += 10; break;
                case 13: finalValue = "K"; _playerCounter += 10; break;
                case 14: finalValue = "A"; _playerCounter += 10; break;
            }
        }
        else
        {
            _playerCounter += value;
            finalValue = value.ToString();
        }
        
        for (int j = 0; j < _playerDealtCards.Count; j++)
        {
            if (j == 0)
            {
                dealtCardsString += _playerDealtCards[j].ToString();
            }
            else
            {
                dealtCardsString += " + " + _playerDealtCards[j];
            }
        }
        playerDealtCardsDisplayer.text = dealtCardsString;
        playerCountDisplayer.text = _playerCounter.ToString();
        

        Check();
        
        playerNumber1.text = finalValue;
        playerNumber2.text = finalValue;
        playerCountDisplayer.text = _playerCounter.ToString();
        hitButton.interactable = true;
        stayButton.interactable = true;
    }

    public void Stay()
    {
        if (_dealerCounter <= 16)
        {
            string dealtCardsString = "";
            List<string> cardNames = _cardsValue.Keys.ToList();
            int value = _cardsValue[cardNames[Random.Range(0, cardNames.Count)]];
            _dealerCounter += value;
            _dealerDealtCards.Add(value);
            for (int j = 0; j < _dealerDealtCards.Count; j++)
            {
                dealtCardsString += _dealerDealtCards[j].ToString();
                dealerNumber1.text = value.ToString();
                dealerNumber2.text = value.ToString();
            }
            dealerCountDisplayer.text = _dealerDealtCards[0].ToString();
            dealerDealtCardsDisplayer.text = dealtCardsString;
        }
        Check();
    }
    
    private IEnumerator HideText(bool type)
    {
        switch (type)
        {
            case true:
            {
                yield return new WaitForSeconds(1f);
                hasWonImage.SetActive(true);
                yield return new WaitForSeconds(2f);
                hasWonImage.SetActive(false);
                PrepareForNewRound();
                break;
            }
            case false:
            {
                yield return new WaitForSeconds(2f);
                notEnoughMoneyText.SetActive(false);
                PrepareForNewRound();
                break;
            }
        }
    }

    private int Check() //0 - lost, 1 - won, 2 - draw
    {
        if (_playerCounter > 21 || _dealerCounter == 21)
        {
            hasWonText.text = "You lost";
            wonMoneyText.text = "";
            StartCoroutine(HideText(true));
            GlobalVariables.CurrentBlackJackBet = 10;
            _playerCounter = 0;
            PrepareForNewRound();
            return 0;
        }
        if (_dealerCounter > 21 || _playerCounter == 21)
        {
            hasWonText.text = "You win";
            wonMoneyText.text = "";
            StartCoroutine(HideText(true));
            GlobalVariables.CurrentBlackJackBet = 10;
            _playerCounter = 0;
            PrepareForNewRound();
            return 1;
        }

        return 2;
    }
}
