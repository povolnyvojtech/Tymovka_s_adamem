using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class DatingWomanProfile : MonoBehaviour
{
    //toto všechno se provádí pouze na WomenProfile prefabu
    
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI ageText;
    public TextMeshProUGUI hobbiesText;
    public Image womanProfilePictureImage;
    public Texture2D profilePicture;
    private Texture2D _myTexture;
    private WomanProfile _womanProfileData;
    public static event Action GenerateNewWomanProfileAction;

    public void GenerateNewWomanProfile(bool way) //way - false - dislike, true - like
    {
        GlobalVariables.Way = way;
        GenerateNewWomanProfileAction.Invoke();
    }

    public void SetupDatingWomanProfile(WomanProfile womanProfile)
    {
        _womanProfileData = womanProfile;
        Debug.Log("Setup WomanProfile");
        RefreshUI();
    }
    
    public void RefreshUI()
    {
        if (_womanProfileData == null) return;
        Debug.Log("Refreshing WomanProfile UI");
        _myTexture = profilePicture;
        Rect rect = new Rect(0, 0, _myTexture.width, _myTexture.height);
        Sprite profilePictureSprite = Sprite.Create(_myTexture, rect, new Vector2(0.5f, 0.5f));
        womanProfilePictureImage.sprite = profilePictureSprite;
        nameText.text = _womanProfileData.ProfileName;
        ageText.text = _womanProfileData.Age;
        hobbiesText.text = _womanProfileData.Hobbies;
    }
}
