using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class NextLevel : MonoBehaviour
{

    SceneChangeManager sceneChangeManager;
    public string lastLevel = "Level2";
    // Start is called before the first frame update
    void Start()
    {
        sceneChangeManager = GameObject.FindObjectOfType<SceneChangeManager>();
        gameObject.SetActive(sceneChangeManager.GetPreviousSceneName() != lastLevel);
    }

    public void LoadNextLevel()
    {
        string lastLevel = sceneChangeManager.GetPreviousSceneName();
        string lastLevelNumberChar = lastLevel.Substring(5); // ignores the 'Level' part of the string
        int currentLevelNumber = 0;

        try
        {
            currentLevelNumber = Int32.Parse(lastLevelNumberChar.ToString());
        } catch
        {
            Debug.Log("Last level has no number?");
        }
        PlayerPrefs.SetInt("current_level", currentLevelNumber + 1);
        sceneChangeManager.LoadScene("Level" + (currentLevelNumber + 1).ToString());
    }
}
