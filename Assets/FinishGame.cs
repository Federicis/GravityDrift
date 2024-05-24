using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    public string targetTag = "Player"; // Tag of the object to interact with
    public string winSceneName = "YouWinScene"; // Name of the win scene

    public AudioClip explosionSound;

    public GameObject audioPlayerPrefab;

    public SceneChangeManager sceneChangeManager;

    public GameManager gameManager;

    private void Start()
    {
        sceneChangeManager = GameObject.FindObjectOfType<SceneChangeManager>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            Finish();
        }
    }

    void Finish() 
    {
        Debug.Log("Game Finished!");
        
        PlayerPrefs.SetInt("collected_coins", gameManager.collectedCoins);
        PlayerPrefs.SetInt("total_coins", gameManager.totalCoins);


        GameObject audioPlayer = Instantiate(audioPlayerPrefab, transform.position, Quaternion.identity);

        // Get the AudioSource component and set the clip
        AudioSource audioSource = audioPlayer.GetComponent<AudioSource>();

        audioSource.clip = explosionSound;
        audioSource.volume = 0.25f;

        // Play the sound
        audioSource.Play();

        // Destroy the audio player after the clip finishes playing
        Destroy(audioPlayer, audioSource.clip.length);

        LoadScene();
    }

    private void LoadScene()
    {
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncOperation = sceneChangeManager.LoadSceneAsync(winSceneName);
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
