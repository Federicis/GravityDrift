using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject rocket;
    public GameObject rocketBoost;
    public GameObject parachute;

    public int totalCoins = 0;
    public int collectedCoins = 0;
    private float deltaTime = 0.0f;

    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0; // Disable VSync

        rocket = GameObject.Find("Rocket");
        rocketBoost = GameObject.Find("RocketBoost");
        parachute = GameObject.Find("Parachute");

        totalCoins = FindObjectsOfType<Collect>().Count();
        Debug.Log("total coins: " + totalCoins);
        collectedCoins = 0;

        rocketBoost.transform.SetParent(rocket.transform);
        rocketBoost.SetActive(false);
        parachute.transform.SetParent(rocket.transform);
        parachute.SetActive(false);
    }

    void Update()
    {

    }
}
