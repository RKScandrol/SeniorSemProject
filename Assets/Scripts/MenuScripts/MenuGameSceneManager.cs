using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static bool isPaused;

    public GameObject pauseMenuPrefab;

    public GameObject settingsMenuPrefab;

    public GameObject mainMenuPrefab;

    public GameObject canvasPrefab;

    private Canvas _canvas;

    private Canvas SceneCanvas {
        get {
            if(_canvas == null) {
                _canvas = FindObjectOfType<Canvas>();

                if(_canvas == null) {
                    _canvas = Instantiate(canvasPrefab).GetComponent<Canvas>();
                }
            }
            return _canvas;
        }
    }

    private GameObject mainMenuInstance;

    public void OpenMainMenu()
    {
        //if(mainMenuInstance == null) {
       //     Instantiate(mainMenuPrefab, SceneCanvas.transform);
       // } else {
       //     mainMenuInstance.SetActive(true);
       // }
        Time.timeScale = 1f;
        SceneManager.LoadScene("Wilson_3");
    }

    public void PlayNowButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Wilson_2");
    }

    private GameObject pauseMenuInstance;

    public void OpenPauseMenu()
    {
        Time.timeScale = 0f;
        if(pauseMenuInstance == null) {
            Instantiate(pauseMenuPrefab, SceneCanvas.transform);
        } else {
            pauseMenuInstance.SetActive(true);
        }
    }

    public void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            OpenPauseMenu();
        }
    }

    private GameObject settingsMenuInstance;

    public void OpenSettingsMenu()
    {
        if(settingsMenuInstance == null) {
            Instantiate(settingsMenuPrefab, SceneCanvas.transform);
        } else {
            settingsMenuInstance.SetActive(true);
        }
    }
     public void QuitButton()
    {
        // Quit Game
        Application.Quit();
        Debug.Log("Game Closed");
    }

}
