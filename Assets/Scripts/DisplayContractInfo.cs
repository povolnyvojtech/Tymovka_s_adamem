using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayContractInfo : MonoBehaviour
{
   public TextMeshProUGUI titleText;
   public TextMeshProUGUI timeText;
   public TextMeshProUGUI xpText;
   public TextMeshProUGUI moneyText;
   public GameObject startContractButton;
   public static DisplayContractInfo Instance { get; private set; }

   private void Awake()
   {
      if (Instance == null)
      {
         Instance = this;
      }
      else
      {
         Destroy(gameObject);
      }
   }

   private void Start()
   {
      titleText.text = "Choose contract";
      timeText.text = "";
      moneyText.text = "";
      xpText.text = "";
      startContractButton.SetActive(false);

   }

   public void DisplayStats(int jobTime, int jobMoney, int jobXp, string jobName) //type 0 - nastavit, 1 - smazat
   {
      startContractButton.SetActive(true);
      titleText.text = jobName;
      timeText.text = "Time: " + jobTime;
      moneyText.text = "Money: " + jobMoney;
      xpText.text = "XP: " + jobXp;
   }

   public void ClearJobInfo()
   {
      titleText.text = "Choose contract";
      timeText.text = "";
      moneyText.text = "";
      xpText.text = "";
      startContractButton.SetActive(false);
   }

}
