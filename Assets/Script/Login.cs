using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public GameObject usernameField;
    public GameObject passwordField;

    public GameObject wrongLoginPopup;
    public void loginClicked()
    {
        if (usernameField.GetComponent<InputField>().text == "admin" && passwordField.GetComponent<InputField>().text == "admin")
        {
            SceneManager.LoadScene(3);
        }
        
        wrongLoginPopup.SetActive(true);
    }

    public void signupClicked()
    {
        /*MainMenu.freetrialStatus = false;*/
        SceneManager.LoadScene(2);
    }
}
