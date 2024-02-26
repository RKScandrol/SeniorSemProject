using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject SettingsMenu;
    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {

        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void GoToSettingsMenu()
    {
        pauseMenu.SetActive(false);
        SettingsMenu.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        isPaused = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
