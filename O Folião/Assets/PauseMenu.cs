using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (GameIsPaused)
            {
                Resume();

            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);

        Time.timeScale = 1f;

        GameIsPaused = false;

        Debug.Log("resume");
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;

        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
