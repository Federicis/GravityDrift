using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject rocket;
    public GameObject rocketBoost;
    public GameObject parachute;

    // Start is called before the first frame update
    void Start()
    {
        rocketBoost.transform.SetParent(rocket.transform);
        rocketBoost.SetActive(false);
        parachute.transform.SetParent(rocket.transform);
        parachute.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
