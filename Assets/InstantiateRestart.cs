using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateRestart : MonoBehaviour
{
    public GameObject buttonPrefab; // Reference to the Button prefab

    void Start()
    {
        // Instantiate the button prefab if it doesn't exist
        if (GameObject.FindObjectOfType<RestartButton>() == null && buttonPrefab != null)
        {
            Instantiate(buttonPrefab, transform.position, Quaternion.identity);
        }
    }
}
