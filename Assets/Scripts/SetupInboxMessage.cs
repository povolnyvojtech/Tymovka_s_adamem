using TMPro;
using UnityEngine;

public class SetupInboxMessage : MonoBehaviour
{
    public TextMeshProUGUI womanNameText;
    public TextMeshProUGUI messageText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        womanNameText.text = "Woman: ";
        messageText.text = "";
    }
}
