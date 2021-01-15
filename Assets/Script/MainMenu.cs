using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool optionPanelStatus = false;
    public static bool freetrialStatus;
    public GameObject optionPanel;

    public void loginClicked()
    {
        freetrialStatus = false;
        SceneManager.LoadScene(1);
    }

    public void freetrialClicked()
    {
        freetrialStatus = true;
        SceneManager.LoadScene(4);
    }

    public void quitClicked()
    {
        Application.Quit();
    }

    public void optionClicked()
    {
        optionPanelStatus = !optionPanelStatus;
        optionPanel.SetActive(optionPanelStatus);
    }
}
