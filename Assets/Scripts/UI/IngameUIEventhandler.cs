using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IngameUIEventhandler
{
    public delegate void PlayerEvents(float value);
    public static event PlayerEvents OnMovementChange;
    public static event PlayerEvents OnRadioactiveChange;

    public static void F_OnMovementChange(float nvalue)
    {
        OnMovementChange(nvalue);
    }

    public static void F_OnRadioactiveChange(float nvalue)
    {
        OnRadioactiveChange(nvalue);
    }
}
