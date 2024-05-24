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
        // Ensure there's only one instance of this object
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public string GetPreviousSceneName()
    {
        return previousScene;
    }

    public void LoadScene(string sceneName)
    {
        previousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    public AsyncOperation LoadSceneAsync(string sceneName)
    {
        previousScene = SceneManager.GetActiveScene().name;
        return SceneManager.LoadSceneAsync(sceneName);
    }
}
