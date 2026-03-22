using UnityEngine;

public class DatingEditProfile : MonoBehaviour
{
    public GameObject registeredDisplay;
    public GameObject notRegisteredDisplay;

    public void ShowEditProfileDisplay()
    {
        registeredDisplay.SetActive(false);
        notRegisteredDisplay.SetActive(true);
    }
}
