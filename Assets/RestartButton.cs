using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private Button button;
    private string gameSceneName = "GameScene";
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(RestartGame);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
