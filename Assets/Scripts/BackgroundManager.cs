using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public class BackgroundManager : MonoBehaviour
{
    public GameObject[] backgrounds;
    public int roomType; //0 - hall, 1 - bedroom
    
    private void ChangeBackground(int index)
    {
        if (index < 0 || index >= backgrounds.Length) return;

        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].SetActive(i == index);
        }
    }
    
    private void Start()
    {
        switch (roomType)
        {
            case 0: ChangeBackground(GlobalVariables.HallBgLevel); GlobalVariables.ActiveScene = "Hall"; break;
            case 1: ChangeBackground(GlobalVariables.BedroomBgLevel); GlobalVariables.ActiveScene = "Bedroom"; break;
        }  
    }
}
