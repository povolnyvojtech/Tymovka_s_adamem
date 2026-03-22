using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DatingAppMeet : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    private List<string> _randomWomanProfileInfo;
    public Transform contentParent;
    public GameObject womanProfilePrefab;
    private bool _generatedProfiles;
    public GameObject panels;
    private readonly List<string> _names = new List<string>()
    {
        "Emma", "Olivia", "Sophia", "Ava", "Isabella", "Mia", "Amelia", "Harper",
        "Evelyn", "Abigail", "Emily", "Elizabeth", "Mila", "Ella", "Avery"
    };
    private readonly List<string> _hobbies = new List<string>()
    {
        "Traveling", "Reading", "Sports", "Painting", "Photography", "Cooking", "Gardening", "Gaming",
        "Music", "Hiking", "Dancing", "Watching movies", "Sewing", "Yoga", "Swimming",
    };
    
    
    
    private void OnEnable()
    {
        titleText.text = GlobalVariables.HasRegistered ? "Meet the love of your life" : "You have to register first";
        if (_generatedProfiles) return;
        if (!GlobalVariables.HasRegistered) { panels.SetActive(false); return; }
        panels.SetActive(true);
        GenerateWomenProfiles();
        InitiateWomenProfiles();
        _generatedProfiles = true;
    }

    private void GenerateWomenProfiles()
    {
        if (GlobalVariables.WomenProfiles.Count == 0)
        {
            for (int i = 0; i < 8; i++)
            {
                _randomWomanProfileInfo = GenerateRandomInfo();
                GlobalVariables.WomenProfiles.Add(new WomanProfile(_randomWomanProfileInfo[0], _randomWomanProfileInfo[1], _randomWomanProfileInfo[2]));
            }
        }
    }
    
    private void InitiateWomenProfiles()
    {
        foreach (WomanProfile profile in GlobalVariables.WomenProfiles)
        {
            GameObject newWomanProfile = Instantiate(womanProfilePrefab, contentParent);
            newWomanProfile.GetComponent<DatingWomanProfile>().SetupDatingWomanProfile(profile);
        }
    }

    private List<string> GenerateRandomInfo()
    {
        string womanName = _names[Random.Range(0, 15)];
        string age = Random.Range(15, 30).ToString();
        string hobbies = "";
        
        for (int i = 0; i < 5; i++)
        {
            if (i == 0)
            {
                hobbies += _hobbies[Random.Range(0, 15)];
            }
            else
            {
                hobbies += ", " + _hobbies[Random.Range(0, 15)];
            }
        }
        
        
        return new List<string>() { womanName, age, hobbies };
    }
}
