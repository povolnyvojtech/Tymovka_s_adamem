using UnityEngine;
using UnityEngine.UI;

public class AssignToTimerManager : MonoBehaviour
{
    public int type;
    public Image electricityImage;
    public Image rentTimerImage;
    
    
    void Start()
    {
        switch (type)
        {
            case 0:
            {
                TimerManagerScript.ElectricityImage = electricityImage;
                break;
            }
            case 1:
            {
                TimerManagerScript.RentImage = rentTimerImage;
                break;
            }
        }
    }
}
