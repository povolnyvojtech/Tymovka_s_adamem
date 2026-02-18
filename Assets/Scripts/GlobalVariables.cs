using System;
using System.Collections.Generic;
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

    public static List<Job> JobOffers =  new List<Job>();
    
    public static void LevelUp()
    {
        Level = (Xp / 150) < 1 ? 1 : Xp / 150;
        HourRate += (Level % 10 == 0) ? 5 : 0;
    }
}
