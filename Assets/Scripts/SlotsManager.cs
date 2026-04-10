using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SlotsManager : MonoBehaviour
{
    public GameObject hasWonImage;
    public Button spinButton;
    public GameObject[] images = new GameObject[3]; 
    public Sprite[] icons = new Sprite[7];
    
    private readonly List<int> _chosenIndexes = new List<int>() {-1,-1,-1};
    private readonly List<int> _spinCount = new List<int>() {10,14,18};
    private bool _isSpinning;

    private event Action FinishedSpinning;
    private int _finishedSlots;
    
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI xpText;
    public TextMeshProUGUI moneyText;
    public GameObject notEnoughMoneyText;
    
    private void Start()
    {
        foreach (var image in images)
        {
            Image imgComponent = image.GetComponent<Image>();
            imgComponent.sprite = icons[Random.Range(0, icons.Length)];
        }

        FinishedSpinning += WinCheck;
    }

    private void Update()
    {
        if (_isSpinning) return;
    }

    public void Spin()
    {
        if (_isSpinning) return;
        if (GlobalVariables.Money < GlobalVariables.CurrentBet)
        {
            StartCoroutine(ShowNotEnoughMoneyText());
            return;
        }
        GlobalVariables.Money -= GlobalVariables.CurrentBet;
        GlobalVariables.UpdateStats(levelText, xpText, moneyText);
        _isSpinning = true;
        
        for (int i = 0; i < images.Length; i++)
        {
            StartCoroutine(ChooseFruits(images[i], i));
        }
    }

    private IEnumerator ShowNotEnoughMoneyText()
    {
        notEnoughMoneyText.SetActive(true);
        yield return new WaitForSeconds(2f);
        notEnoughMoneyText.SetActive(false);
    }

    private IEnumerator ChooseFruits(GameObject slot, int currentImageIndex)
    {
        int chosenIndex = 0;
        Image imgComponent = slot.GetComponent<Image>();
        for (int i = 0; i < _spinCount[currentImageIndex]; i++)
        {
            chosenIndex = Random.Range(0, icons.Length); 
            imgComponent.sprite = icons[chosenIndex]; 
            yield return new WaitForSeconds(0.1f);
        }
        _chosenIndexes[currentImageIndex] = chosenIndex;
        FinishedSpinning?.Invoke();
    }

    private void WinCheck()
    {
        ++_finishedSlots;
        if (_finishedSlots != 3) return;
        _finishedSlots = 0;
        if (_chosenIndexes[0] == _chosenIndexes[1] && _chosenIndexes[1] == _chosenIndexes[2])
        {
            hasWonImage.SetActive(true);
            StartCoroutine(HideHasWonText());
            GlobalVariables.Money += 30*GlobalVariables.CurrentBet;
            GlobalVariables.UpdateStats(levelText, xpText, moneyText);
        }
        _isSpinning = false;
    }

    private IEnumerator HideHasWonText()
    {
        spinButton.interactable = false;
        yield return new WaitForSeconds(2f);
        spinButton.interactable = true; 
        hasWonImage.SetActive(false);
    }
}