using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_MainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    //public GameObject SettingsMenu;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
    }

    public void PlayNowButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        UnityEngine.SceneManagement.SceneManager.LoadScene("Wilson_2");
    }

    //public void SettingsButton()
    //{
        // Show Settings Menu
    //    MainMenu.SetActive(false);
        //SettingsMenu.SetActive(true);
    //}

    public void MainMenuButton()
    {
        // Show Main Menu
        MainMenu.SetActive(true);
        //SettingsMenu.SetActive(false);
        SceneManager.LoadScene("Wilson_3");
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
        Debug.Log("Game Closed");
    }
}