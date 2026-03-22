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
    public Image womanProfilePicture;
    public Texture2D[] profilePictures;
    private Texture2D _myTexture;
    private WomanProfile _womanProfileData;

    public void SetupDatingWomanProfile(WomanProfile womanProfile)
    {
        _womanProfileData = womanProfile;
        RefreshUI();
    }
    
    public void RefreshUI()
    {
        if (_womanProfileData == null) return;
        _myTexture = profilePictures[UnityEngine.Random.Range(0, 4)];
        Rect rect = new Rect(0, 0, _myTexture.width, _myTexture.height);
        Sprite profilePictureSprite = Sprite.Create(_myTexture, rect, new Vector2(0.5f, 0.5f));
        womanProfilePicture.sprite = profilePictureSprite;
        nameText.text = _womanProfileData.ProfileName;
        ageText.text = _womanProfileData.Age;
        hobbiesText.text = _womanProfileData.Hobbies;
    }
}
