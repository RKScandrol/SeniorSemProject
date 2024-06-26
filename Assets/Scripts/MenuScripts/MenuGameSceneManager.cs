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
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameObject.FindGameObjectWithTag("FloorManager"));
        Destroy(GameObject.FindGameObjectWithTag("Clock"));
        Destroy(GameObject.FindGameObjectWithTag("MusicManager"));
        Time.timeScale = 1f;
        SceneManager.LoadScene("main_menu_final");
    }

    public void PlayNowButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("bedroom_final");
    }
    
    //private GameObject pauseMenuInstance;
    public GameObject PauseMenu;

     public void OpenPauseMenu()
     {
        /*
        if(pauseMenuInstance == null) {
            pauseMenuInstance = Instantiate(pauseMenuPrefab, SceneCanvas.transform);            
            pauseMenuInstance.SetActive(true);
            Time.timeScale = 0f;
        } else {
            bool isActive = pauseMenuInstance.activeSelf;
            pauseMenuInstance.SetActive(!isActive);
            if(isActive) {
                Time.timeScale = 1f;
            }
            else {
                Time.timeScale = 0f;
            }
        }
        */
        bool isActive = PauseMenu.activeSelf;
            PauseMenu.SetActive(!isActive);
            if(isActive) {
                PauseMenu.SetActive(!isActive);
                Time.timeScale = 1f;
            }
            else {
                PauseMenu.SetActive(!isActive);
                Time.timeScale = 0f;
            }
        

     }

    
    public void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            OpenPauseMenu();
        }
    }

    //private GameObject settingsMenuInstance;
    public GameObject SettingsMenu;

    public void OpenSettingsMenu()
    {
        //if(settingsMenuInstance == null) {
        //    settingsMenuInstance = Instantiate(settingsMenuPrefab, SceneCanvas.transform);
        //} else {
         //   bool isActive = settingsMenuInstance.activeSelf;
         //   settingsMenuInstance.SetActive(!isActive);
       // }

       //bool isActive = SettingsMenu.activeSelf;
       SettingsMenu.SetActive(true);
        
    }

    public void CloseSettingsMenu() {
        /*if(settingsMenuInstance != null) {
            bool isActive = settingsMenuInstance.activeSelf;
            settingsMenuInstance.SetActive(!isActive);
        }*/
        if(SettingsMenu != null) {
            //bool isActive = SettingsMenu.activeSelf;
            SettingsMenu.SetActive(false);
        }
    }

     public void QuitButton()
    {
        // Quit Game
        Application.Quit();
        Debug.Log("Game Closed");
    }

}
