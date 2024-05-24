using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketHitsPlanetDetector : MonoBehaviour
{
    string loseSceneName = "YouLoseScene";

    private SceneChangeManager sceneChangeManager;

    private void Start()
    {
        sceneChangeManager = GameObject.FindObjectOfType<SceneChangeManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("RIP");
        LoadScene();
    }

    private void LoadScene()
    {
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncOperation = sceneChangeManager.LoadSceneAsync(loseSceneName);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
            if (asyncOperation.progress >= 0.9f)
            {
                // Allow the scene to activate
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
