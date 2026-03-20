using TMPro;
using UnityEngine;

public class DatingAppMeet : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    
    private void OnEnable()
    {
        titleText.text = GlobalVariables.HasRegistered ? "Meet the love of your life" : "You have to register first";
    }
}
