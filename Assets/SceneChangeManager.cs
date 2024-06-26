using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    private string previousScene;

    private static SceneChangeManager instance;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public string GetPreviousSceneName()
    {
        return previousScene;
    }

    public void LoadScene(string sceneName)
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name.StartsWith("Level"))
            previousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    public AsyncOperation LoadSceneAsync(string sceneName)
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name.StartsWith("Level"))
            previousScene = SceneManager.GetActiveScene().name;
        return SceneManager.LoadSceneAsync(sceneName);
    }
}
