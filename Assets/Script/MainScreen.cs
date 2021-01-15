using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour
{
    public GameObject bagPanel;
    public GameObject shopPanel;

    private static bool bagPanelStatus = false;
    private static bool shopPanelStatus = false;
    
    public void bagClicked()
    {
        if (shopPanelStatus)
        {
            shopPanelStatus = false;
            shopPanel.SetActive(shopPanelStatus);
        }
        bagPanelStatus = true;
        bagPanel.SetActive(bagPanelStatus);
    }

    public void shopClicked()
    {
        if (bagPanelStatus)
        { 
            bagPanelStatus = false;
            bagPanel.SetActive(bagPanelStatus);
        }
        shopPanelStatus = true;
        shopPanel.SetActive(shopPanelStatus);
    }

    public void backClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void startClicked()
    {
        SceneManager.LoadScene(4);
    }
}
