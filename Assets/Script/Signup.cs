using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Signup : MonoBehaviour
{
    public GameObject passwordField;
    public GameObject repasswoldFeild;
    public GameObject errorPopup;
    public void confirmClicked()
    {
        if (passwordField.GetComponent<InputField>().text == repasswoldFeild.GetComponent<InputField>().text)
        {
            SceneManager.LoadScene(3);
        }
        errorPopup.SetActive(true);
    }

}
