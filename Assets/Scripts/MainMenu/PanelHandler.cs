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
    public GameObject P_Introduction;
    public GameObject B_Back;
    public GameObject B_Credits;
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
            case "Begin":
                _newPanel = P_Introduction;
                break;
            default:
                break;
        }
        if (nPanel == "Begin")
        {
            B_Credits.gameObject.SetActive(false);
        }
        else
        {
            B_Credits.gameObject.SetActive(true);
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
