using TMPro;
using UnityEngine;

public class DatingApp : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI surnameText;
    public GameObject meetButton;
    
    void Start()
    {
        if (!GlobalVariables.DatingHasRegistered)
        {
            DatingRegistration.userHasRegistered += UpdateUserInfo;
        }
    }

    private void UpdateUserInfo()
    {
        GlobalVariables.DatingHasRegistered = true;
        meetButton.SetActive(true);
        if (GlobalVariables.DatingName != "" || GlobalVariables.DatingSurname != "")
        {
            nameText.text = GlobalVariables.DatingName;
            surnameText.text = GlobalVariables.DatingSurname;
        }
        else
        {
            nameText.text = "";
            surnameText.text = "";
        }
    }
}
