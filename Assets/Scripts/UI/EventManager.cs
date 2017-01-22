using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public delegate void LightManager();
    public static event LightManager Lights;


    public static void F_Lights()
    {
        Lights();
    }

}
