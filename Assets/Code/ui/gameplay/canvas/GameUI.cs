using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameUI : MonoBehaviour {

    public Text scoreText;
    public Text healthText;

    private AirplaneScore airplaneScore;
    private HealthHandler airplaneHealth;

    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (airplaneScore == null) {
            airplaneScore = FindObjectOfType<AirplaneScore>();
            return;
        }
        if (airplaneHealth == null) {
            GameObject gameObject = GameObject.FindGameObjectWithTag("Airplane");
            if (gameObject != null)
                airplaneHealth = gameObject.GetComponent<HealthHandler>();
            return;
        }

        scoreText.text = airplaneScore.score.ToString();
        healthText.text = airplaneHealth.currentHealth.ToString();
    }
}
