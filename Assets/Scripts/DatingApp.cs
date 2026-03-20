using TMPro;
using UnityEngine;

public class DatingApp : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI surnameText;
    
    void Start()
    {
        if (!GlobalVariables.HasRegistered)
        {
            DatingRegistration.userHasRegistered += UpdateUserInfo;
        }
    }

    private void UpdateUserInfo()
    {
        GlobalVariables.HasRegistered = true;
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
