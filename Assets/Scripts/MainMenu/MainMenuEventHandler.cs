using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MainMenuEventHandler
{
    public delegate void MenuEvents(string newPanel);
    public static event MenuEvents OnPanelClick;


    #region Functions
    public static void F_OnPanelClick(string nPanel)
    {
        OnPanelClick(nPanel);
    }
    #endregion
}
