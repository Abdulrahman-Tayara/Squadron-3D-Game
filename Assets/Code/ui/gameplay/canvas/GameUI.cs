using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameUI : MonoBehaviour {

    public Text scoreText;
    public Slider healthBar;

    private AirplaneScore airplaneScore;
    private HealthHandler airplaneHealth;

    void Start() {

    }

    void Update() {
        if (airplaneScore == null) {
            airplaneScore = FindObjectOfType<AirplaneScore>();
            return;
        }
        if (airplaneHealth == null) {
            GameObject gameObject = GameObject.FindGameObjectWithTag("Airplane");
            if (gameObject != null) {
                airplaneHealth = gameObject.GetComponent<HealthHandler>();
                healthBar.maxValue = airplaneHealth.maxHealth;
            }
            return;
        }

        scoreText.text = airplaneScore.score.ToString();
        healthBar.value = airplaneHealth.currentHealth;
    }

}
