using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class OptionsScreen : MonoBehaviour {
    public Slider SFXSlider;
    public AudioSource audioSource;

    public List<Vector2> resolutions = new List<Vector2>();
    private int selectedResolutionIndex = 0;

    private string mainMenuScene = "MainMenuScene";

    public TMP_Text resolutionText;

    void Start() {

        for(int i = 0; i < resolutions.Count; i++) {
            if(Screen.width == (int)resolutions[i].x && Screen.height == (int)resolutions[i].y) {
                selectedResolutionIndex = i;
                break;
            }
        }
        UpdateResText();

        SFXSlider.value = audioSource.volume;
    }

    public void ResLeft() {
        selectedResolutionIndex--;
        if(selectedResolutionIndex < 0) selectedResolutionIndex = resolutions.Count - 1;
        UpdateResText();
    }

    public void ResRight() {
        selectedResolutionIndex++;
        if(selectedResolutionIndex >= resolutions.Count) selectedResolutionIndex = 0;
        UpdateResText();
    }

    public void UpdateResText() {
        resolutionText.text = resolutions[selectedResolutionIndex].x + " x " + resolutions[selectedResolutionIndex].y;
    }

    public void ApplyOptions() {
        Screen.SetResolution((int)resolutions[selectedResolutionIndex].x, (int)resolutions[selectedResolutionIndex].y, (Screen.fullScreen ? UnityEngine.FullScreenMode.FullScreenWindow : UnityEngine.FullScreenMode.Windowed));
    }

    public void SaveAndQuit() {
        SceneManager.LoadScene(mainMenuScene);
        DataPersistenceManager.instance.SaveGame();
    }

    public void OnSLiderChange()
    {
        audioSource.volume = SFXSlider.value;
    }

    public void OnDisable()
    {
        PlayerPrefs.SetFloat("volume", SFXSlider.value);
    }
}