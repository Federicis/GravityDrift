using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class NextLevel : MonoBehaviour
{

    SceneChangeManager sceneChangeManager;
    public string stop_level = "Level5";
    // Start is called before the first frame update
    void Start()
    {
        sceneChangeManager = GameObject.FindObjectOfType<SceneChangeManager>();
        gameObject.SetActive(sceneChangeManager.GetPreviousSceneName() != stop_level);
    }

    public void LoadNextLevel()
    {
        string lastLevel = sceneChangeManager.GetPreviousSceneName();
        string lastLevelNumberChar = lastLevel.Substring(5); // ignores the 'Level' part of the string
        int currentLevelNumber = -1;

        try
        {
            currentLevelNumber = int.Parse(lastLevelNumberChar.ToString());
        } catch
        {
            Debug.LogError("Last level has no number?");
        }
        Debug.Log("Next level: " + (currentLevelNumber+1).ToString());
        PlayerPrefs.SetInt("current_level", currentLevelNumber + 1);
        sceneChangeManager.LoadScene("Level" + (currentLevelNumber + 1).ToString());
    }
}
