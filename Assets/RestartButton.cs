using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private Button button;
    private SceneChangeManager sceneChangeManager;
    void Start()
    {
        button = GetComponent<Button>();
        sceneChangeManager = GameObject.FindObjectOfType<SceneChangeManager>();
    }

    public void RestartGame()
    {
        if (!SceneManager.GetActiveScene().name.StartsWith("Level"))
            sceneChangeManager.LoadScene(sceneChangeManager.GetPreviousSceneName());
        else
            sceneChangeManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
