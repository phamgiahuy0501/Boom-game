using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuPanel;
    public GameObject gameOverPanel;
    // Update is called once per frame

    private void Start()
    {
        GameIsPaused = false;
        pauseMenuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else {
                Pause();
            }
        }

        if (Player.currentHealth <= 0)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Resume()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        Player.currentHealth = 100;
        pauseMenuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
        if (MainMenu.freetrialStatus)
        {
            SceneManager.LoadScene(0);
        } else
        {
            SceneManager.LoadScene(3);
        }
        
    }
}
