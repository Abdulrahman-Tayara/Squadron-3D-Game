using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FinishMenu : MonoBehaviour {

    public TextMeshProUGUI scoreText, coinsText;

    private int score = 0, coins = 0;

    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (scoreText != null)
            scoreText.text = score.ToString();
        if (coinsText != null)
            coinsText.text = coins.ToString();
    }

    public void setData(int score, int coins) {
        this.score = score;
        this.coins = coins;
    }
}
