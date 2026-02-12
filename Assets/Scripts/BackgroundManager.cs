using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject[] backgrounds;
    
    private void ChangeBackground(int i)
    {
        backgrounds[i].SetActive(true); //i je vlastne GlobalVariable.ConstructionLevel
    }
}
