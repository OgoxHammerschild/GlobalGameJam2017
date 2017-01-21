using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void OnOptionsButtonClick()
    {
        MainMenuEventHandler.F_OnPanelClick("P_Options");
    }

    public void OnBackButtonClick()
    {
        MainMenuEventHandler.F_OnPanelClick("Return");
    }
}
