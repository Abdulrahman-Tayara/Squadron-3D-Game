using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneManager : MonoBehaviour {

    private static AirplaneManager singleton;

    private GameObject airplaneObject;
    private Airplane airplane;
    private Airplane.AirplaneAttributes airplaneAttributes;
    private GameState gameState;

    public static AirplaneManager getInstance() {
        return singleton;
    }

    private void Awake() {
        singleton = this;
    }


    // Update is called once per frame
    void Update() {
        
    }

    private void initAirplane() {
        GetComponent<AirplaneMovment>().setSpeedValues(airplaneAttributes.speed, airplaneAttributes.minSpeed, airplaneAttributes.maxSpeed);
        GetComponent<AirplaneAttack>().setDamage(airplaneAttributes.basicDamage, airplaneAttributes.specialDamage);
    }

    // Called from GameController
    public void setAirplane(Airplane airplane, GameState gameState) {
        this.airplane = airplane;
        this.airplaneAttributes = airplane.attributes;
        this.gameState = gameState;
        this.gameState.health = (int) Mathf.Clamp(gameState.health, 0f, airplane.attributes.maxHealth);
        initAirplane();
    }

    public void onAirplaneCollision(Collision collision) {
        Collider collider = collision.collider;
        if (collider.CompareTag("Terrain")) {
            Debug.Log("Airplane dead");
        }
    }
}
