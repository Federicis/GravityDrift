using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinOverlayController : MonoBehaviour
{
    public TMP_Text coinsText;
    // Start is called before the first frame update
    void Start()
    {
        int collectedCoins = PlayerPrefs.GetInt("collected_coins");
        int totalCoins = PlayerPrefs.GetInt("total_coins");
        coinsText.text = collectedCoins.ToString() + " / " + totalCoins.ToString();
    }
}
