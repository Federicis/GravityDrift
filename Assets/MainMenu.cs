using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    public string gameScene = "Level";
    public GameObject optionsScreen;
    public AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartNewGame()
    {
        PlayerPrefs.SetInt("current_level", 1);
        SceneManager.LoadScene(gameScene + "1");
    }

    public void LoadGame()
    {
        int currentLevel = PlayerPrefs.GetInt("current_level");
        SceneManager.LoadScene(gameScene + currentLevel.ToString());
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
        float volume = PlayerPrefs.GetFloat("volume");
        audioSource.volume = volume;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
