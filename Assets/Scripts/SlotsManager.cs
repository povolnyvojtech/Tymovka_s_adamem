using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotsManager : MonoBehaviour
{
    public GameObject hasWonImage;
    public Button spinButton;
    public GameObject[] images = new GameObject[3]; 
    public Sprite[] icons = new Sprite[7]; 
    
    private int _chosenIndex;
    private readonly List<int> _chosenIndexes = new List<int>() {0, 0, 0};
    private bool _isSpinning = false;

    public void Spin()
    {
        if (_isSpinning) return;
        _isSpinning = true;
        
        for (int i = 0; i < images.Length; i++)
        {
            Image imgComponent = images[i].GetComponent<Image>(); 
            for (int j = 0; j <= 8; j++) //TODO wait for a bit then show
            {
                _chosenIndex = Random.Range(0, icons.Length); 
                imgComponent.sprite = icons[_chosenIndex]; 
            }
            _chosenIndexes[i] = _chosenIndex;
        }

        if (_chosenIndexes[0] == _chosenIndexes[1] && _chosenIndexes[1] == _chosenIndexes[2])
        {
            hasWonImage.SetActive(true);
            StartCoroutine(HideHasWonText());
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