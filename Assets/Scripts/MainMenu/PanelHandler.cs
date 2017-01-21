using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelHandler : MonoBehaviour
{
    public GameObject P_MainMenu;
    public GameObject P_Options;
    public GameObject P_Credits;
    public GameObject P_Quit;
    public GameObject B_Back;
    GameObject _currentPanel;
    GameObject _newPanel;
    GameObject _lastPanel;

    void Start()
    {
        _currentPanel = P_MainMenu;
        SetupEvents();
    }

    private void SetupEvents()
    {
        MainMenuEventHandler.OnPanelClick += MainMenuEventHandler_OnPanelClick;
    }

    private void MainMenuEventHandler_OnPanelClick(string _newPanel)
    {
        SetNewPanel(_newPanel);
        ChangePanel();
    }

    void SetNewPanel(string nPanel)
    {
        switch (nPanel)
        {
            case "P_Options":
                _newPanel = P_Options;
                break;
            case "P_Credits":
                _newPanel = P_Credits;
                break;
            case "P_MainMenu":
                _newPanel = P_MainMenu;
                break;
            case "Quit":
                _newPanel = P_Quit;
                break;
            case "Return":
                _newPanel = _lastPanel;
                break;
            default:
                break;
        }
    }

    void ChangePanel()
    {
        _lastPanel = _currentPanel;
        _currentPanel.gameObject.SetActive(false);
        _currentPanel = _newPanel;
        _currentPanel.gameObject.SetActive(true);
    }
}
