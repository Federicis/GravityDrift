using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class NextLevel : MonoBehaviour
{

    SceneChangeManager sceneChangeManager;
    // Start is called before the first frame update
    void Start()
    {
        sceneChangeManager = GameObject.FindObjectOfType<SceneChangeManager>();
        gameObject.SetActive(sceneChangeManager.GetPreviousSceneName() != "Level2");
    }

    public void LoadNextLevel()
    {
        string lastLevel = sceneChangeManager.GetPreviousSceneName();
        char lastLevelNumberChar = lastLevel[lastLevel.Length - 1];
        int currentLevelNumber = 0;

        if (char.IsDigit(lastLevelNumberChar))
        {
            currentLevelNumber = int.Parse(lastLevelNumberChar.ToString()) + 1;
        } else
        {
            Debug.Log("Last level has no number?");
        }
        sceneChangeManager.LoadScene("Level" + currentLevelNumber.ToString());
    }
}
