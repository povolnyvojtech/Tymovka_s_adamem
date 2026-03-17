using System;
using TMPro;
using UnityEngine;

public class DisplayContractInfo : MonoBehaviour
{
   public TextMeshProUGUI titleText;
   public TextMeshProUGUI timeText;
   public TextMeshProUGUI xpText;
   public TextMeshProUGUI moneyText;
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
      timeText.text = "Choose contract";
      timeText.text = "";
      moneyText.text = "";
      xpText.text = "";
   }

   public void DisplayStats(int jobTime, int jobMoney, int jobXp, string jobName, int type) //type 0 - nastavit, 1 - smazat
   {
      titleText.text = jobName;
      timeText.text = "Time: " + jobTime;
      moneyText.text = "Money: " + jobMoney;
      xpText.text = "XP: " + jobXp;
   }

}
