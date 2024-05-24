using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class OverlayController : MonoBehaviour
{
    public TMP_Text scoreText;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("score text: " + scoreText);
        gameManager = FindObjectOfType<GameManager>();
        Debug.Log("game manager: " + gameManager);
    }

    // Update is called once per frame
    void Update()
    {
        FormatScoreText();
    }

    void FormatScoreText()
    {
        scoreText.text = gameManager.collectedCoins.ToString() + " / " + gameManager.totalCoins.ToString() + " Coins";
    }
}
