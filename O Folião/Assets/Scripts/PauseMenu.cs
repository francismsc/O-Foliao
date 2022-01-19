using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject game;

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

        game.GetComponent<Game>().enabled = true;
        game.GetComponent<Movement>().enabled = true;

        GameIsPaused = false;

        Debug.Log("resume");
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);

        game.GetComponent<Game>().enabled = false;
        game.GetComponent<Movement>().enabled = false;

        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        pauseMenuUI.SetActive(false);

        SceneManager.LoadScene("Start Menu");
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
