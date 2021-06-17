using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject alertBox;
    public AudioMixer mixer;
    public Slider masterVolumeSlider;

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
        GameManager.Instance.ChangeGameState(GameManager.GameState.PLAYING);
        SceneManager.LoadScene("Level");
    }

    public void ChangeMasterVolume(float masterVolume)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(masterVolume) * 20);
    }

    public void SaveOptions()
    {
        Debug.Log("Saving Options");
        float mixerMasterVolume;
        mixer.GetFloat("MasterVolume", out mixerMasterVolume);
        PlayerPrefs.SetFloat("MasterVolume", mixerMasterVolume);
        PlayerPrefs.SetFloat("MasterVolumeSlider", masterVolumeSlider.value);
    }

    public void LoadOptions()
    {
        Debug.Log("Loading Options");
        float mixerMasterVolume = PlayerPrefs.GetFloat("MasterVolume", 0f);
        mixer.SetFloat("MasterVolume", mixerMasterVolume);
        float masterSliderValue = PlayerPrefs.GetFloat("MasterVolumeSlider", 1f);
        masterVolumeSlider.value = masterSliderValue;
    }

    private void Start()
    {
        LoadOptions();
    }

    public void CheckForChanges()
    {
        float savedMasterVolume = PlayerPrefs.GetFloat("MasterVolume", 0f);
        float actualMasterVolume;
        mixer.GetFloat("MasterVolume", out actualMasterVolume);

        // TODO: Actually set this information up in code and in editor.
        float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0f);
        float actualMusicVolume;
        mixer.GetFloat("MusicVolume", out actualMusicVolume);

        // TODO: Actually set this information up in code and in editor.
        float savedSFXVolume = PlayerPrefs.GetFloat("SFXVolume", 0f);
        float actualSFXVolume;
        mixer.GetFloat("SFXVolume", out actualSFXVolume);

        if (Mathf.Approximately(savedMasterVolume, actualMasterVolume) &&
            Mathf.Approximately(savedMusicVolume, actualMusicVolume) &&
            Mathf.Approximately(savedSFXVolume, actualSFXVolume))
        {
            // The values are the same
            CloseOptionsMenu();
        }
        else
        {
            // The values are different
            ShowAlertBox();
        }
    }

    public void ShowAlertBox()
    {
        optionsMenu.SetActive(false);
        alertBox.SetActive(true);
    }

    public void CloseAlertBox()
    {
        mainMenu.SetActive(true);
        alertBox.SetActive(false);
    }
}
