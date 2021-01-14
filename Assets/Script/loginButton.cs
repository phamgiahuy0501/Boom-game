using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loginButton : MonoBehaviour
{
    public GameObject usernameField;
    public GameObject passwordField;

    private string constUser = "Admin";
    private string constPass = "Admin";
    public void process()
    {
        Debug.Log(usernameField.GetComponent<InputField>().text);
        Debug.Log(passwordField.GetComponent<InputField>().text);
        Debug.Log("ok");
    }
}
