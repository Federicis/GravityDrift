using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public string targetTag = "Player"; // Tag of the object to interact with
    public GameObject audioPlayerPrefab;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            GameObject audioPlayer = Instantiate(audioPlayerPrefab, transform.position, Quaternion.identity);

            // Get the AudioSource component and set the clip
            AudioSource audioSource = audioPlayer.GetComponent<AudioSource>();

            // Play the sound
            audioSource.Play();

            // Destroy the audio player after the clip finishes playing
            Destroy(audioPlayer, audioSource.clip.length);
            Destroy(gameObject);
        }
    }
}
