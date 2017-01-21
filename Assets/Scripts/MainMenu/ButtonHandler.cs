using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    #region MainMenu

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("Cellar");
    }

    public void OnOptionsButtonClick()
    {
        MainMenuEventHandler.F_OnPanelClick("P_Options");
    }

    public void OnBackButtonClick()
    {
        MainMenuEventHandler.F_OnPanelClick("Return");
    }

    public void OnQuitButtonClick()
    {
        MainMenuEventHandler.F_OnPanelClick("Quit");
    }
    #endregion

    #region QuitPanel

    public void OnYesButtonClick()
    {
        Application.Quit();
    }

    public void OnNoButtonClick()
    {
        MainMenuEventHandler.F_OnPanelClick("Return");
    }
    #endregion
}
