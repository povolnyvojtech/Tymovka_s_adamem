using TMPro;
using UnityEngine;

public class SetupJob : MonoBehaviour
{
    public TextMeshProUGUI typeText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI moneyText;
    
    public void Setup(string jobType, int time, int money)
    {
        typeText.text = "Type of job: " + jobType;
        timeText.text = "Time: " + time;
        moneyText.text = "Money:" + money;
    }
}
