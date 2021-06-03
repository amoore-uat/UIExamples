using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    public void QuitGame()
    {
        Debug.Log("Quitting the game");
        Application.Quit();
    }

    public void DisplayOptionsMenu()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void CloseOptionsMenu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void StartNewGame()
    {
        // SceneManager.LoadScene("Level");
        SceneManager.LoadScene(1);
    }
}
