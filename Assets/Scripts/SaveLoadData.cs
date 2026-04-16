using UnityEngine;

public class SaveLoadData : MonoBehaviour
{
    public void SaveData()
    {
        #if UNITY_EDITOR || UNITY_WEBGL
                Debug.Log("Saving data does not work in editor or web.");
                return;
        #endif
        
        //BG variables
        PlayerPrefs.SetInt("HallBgLevel", GlobalVariables.HallBgLevel);
        PlayerPrefs.SetInt("CurrentHallBgUpgradeCost", GlobalVariables.CurrentHallBgUpgradeCost);
        PlayerPrefs.SetInt("BedroomBgLevel", GlobalVariables.BedroomBgLevel);
        PlayerPrefs.SetInt("CurrentBedroomBgUpgradeCost", GlobalVariables.CurrentBedroomBgUpgradeCost);
        
        //practice variables
        PlayerPrefs.SetInt("QualityLevel", GlobalVariables.QualityLevel);
        PlayerPrefs.SetFloat("QualityMultiplier", GlobalVariables.QualityMultiplier);
        PlayerPrefs.SetInt("SpeedLevel", GlobalVariables.SpeedLevel);
        PlayerPrefs.SetFloat("SpeedMultiplier", GlobalVariables.SpeedMultiplier);
        PlayerPrefs.SetInt("QualityPractisingTime", GlobalVariables.QualityPractisingTime);
        PlayerPrefs.SetInt("SpeedPractisingTime", GlobalVariables.SpeedPractisingTime);
        
        //career variables
        PlayerPrefs.SetInt("HasCareer",  GlobalVariables.HasCareer ? 1 : 0); //change to int - 1 - hasCareer, 0 - doesntHaveCareer, 
        PlayerPrefs.SetString("CareerPath", GlobalVariables.CareerPath);
        PlayerPrefs.SetInt("Money", GlobalVariables.Money);
        PlayerPrefs.SetInt("Level", GlobalVariables.Level);
        PlayerPrefs.SetInt("Xp", GlobalVariables.Xp);
        
        //dating variables
        PlayerPrefs.SetFloat("GymLevel", GlobalVariables.GymLevel);
        PlayerPrefs.SetFloat("OverallLook", GlobalVariables.OverallLook);
        PlayerPrefs.SetFloat("ChanceToGetHoes", GlobalVariables.ChanceToGetHoes);
        PlayerPrefs.SetString("DatingName", GlobalVariables.DatingName);
        PlayerPrefs.SetString("DatingSurname", GlobalVariables.DatingSurname);
        PlayerPrefs.SetInt("DatingHasRegistered", GlobalVariables.DatingHasRegistered ? 1 : 0); //same as hasCareer
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        #if UNITY_EDITOR || UNITY_WEBGL
                Debug.Log("Saving data does not work in editor or web.");
                return;
        #endif
        GlobalVariables.HallBgLevel = PlayerPrefs.GetInt("HallBgLevel");
        GlobalVariables.CurrentHallBgUpgradeCost = PlayerPrefs.GetInt("CurrentHallBgUpgradeCost");
        GlobalVariables.BedroomBgLevel = PlayerPrefs.GetInt("BedroomBgLevel");
        GlobalVariables.CurrentBedroomBgUpgradeCost = PlayerPrefs.GetInt("CurrentBedroomBgUpgradeCost");
        GlobalVariables.QualityLevel = PlayerPrefs.GetInt("QualityLevel");
        GlobalVariables.QualityMultiplier = PlayerPrefs.GetFloat("QualityMultiplier");
        GlobalVariables.SpeedLevel = PlayerPrefs.GetInt("SpeedLevel");
        GlobalVariables.SpeedMultiplier = PlayerPrefs.GetFloat("SpeedMultiplier");
        GlobalVariables.QualityPractisingTime = PlayerPrefs.GetInt("QualityPractisingTime");
        GlobalVariables.SpeedPractisingTime = PlayerPrefs.GetInt("SpeedPractisingTime");
        GlobalVariables.HasCareer = PlayerPrefs.GetInt("HasCareer") ==  1;
        GlobalVariables.CareerPath = PlayerPrefs.GetString("CareerPath");
        GlobalVariables.Money = PlayerPrefs.GetInt("Money");
        GlobalVariables.Level = PlayerPrefs.GetInt("Level");
        GlobalVariables.Xp = PlayerPrefs.GetInt("Xp");
        GlobalVariables.GymLevel = PlayerPrefs.GetInt("GymLevel");
        GlobalVariables.OverallLook = PlayerPrefs.GetFloat("OverallLook");
        GlobalVariables.ChanceToGetHoes = PlayerPrefs.GetFloat("ChanceToGetHoes");
        GlobalVariables.DatingName = PlayerPrefs.GetString("DatingName");
        GlobalVariables.DatingSurname = PlayerPrefs.GetString("DatingSurname");
        GlobalVariables.DatingHasRegistered = PlayerPrefs.GetInt("DatingHasRegistered")==1;
    }
}
