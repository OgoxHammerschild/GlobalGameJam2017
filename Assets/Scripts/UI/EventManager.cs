using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public delegate void LightManager();
    public static event LightManager Lights;

    public delegate void GameOver();
    public static event GameOver Radiaton, Chase;


    public static void F_Lights()
    {
        Lights();
    }


    public static void F_Radiation()
    {
        Radiaton();
    }

    public static void F_Chase()
    {
        Chase();
    }
}
