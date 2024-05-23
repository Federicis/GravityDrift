using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    public string gameScene = "GameScene";
    public GameObject optionsScreen;
    public AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(gameScene);
        PlayerPrefs.SetInt("new_game", 1);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(gameScene);
        PlayerPrefs.SetInt("new_game", 0);
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
