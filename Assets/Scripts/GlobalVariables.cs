using System;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static int ConstructionLevel = 0;
    public static bool HasCareer = false;
    public static string CareerPath = "None"; //vždy formát - TYPPROFESEzamereni - GDgodot 

    public static int Money = 1000;
    
    public static int HourRate = 10; //- hodinova sazba (cim vetsi Level, tim vetsi sazba)
    public static int Level = 1;
    public static int Xp;

    private static void CalcHourRate()
    {
        HourRate += Level switch
        {
            >= 1 and <= 9 => 0,
            >= 10 and <= 19 => 5,
            >= 20 and <= 29 => 5,
            >= 30 and < 39 => 5,
            > 40 => 15,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
    public static void LevelUp()
    {
        Level = (Xp / 150) < 1 ? 1 : Xp / 150;
        if (Level % 10 == 0)
        {
            RaiseHourRate();
        }
    }

    private static void RaiseHourRate()
    {
        switch (Level)
        {
            case 10:
            case 20:
            case 30:
            case 40: CalcHourRate(); break;
        }
    }
}
