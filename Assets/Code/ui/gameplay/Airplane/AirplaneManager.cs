using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneManager : MonoBehaviour {

    private static AirplaneManager singleton;

    private Airplane airplane;
    private Airplane.AirplaneAttributes airplaneAttributes;
    private GameState gameState;

    private HealthHandler healthHandler;

    public static AirplaneManager getInstance() {
        return singleton;
    }

    private void Awake() {
        singleton = this;
        healthHandler = GetComponent<HealthHandler>();
    }


    // Update is called once per frame
    void Update() {

    }

    private void initAirplane() {
        GetComponent<AirplaneMovment>().setSpeedValues(airplaneAttributes.speed, airplaneAttributes.minSpeed, airplaneAttributes.maxSpeed);
        GetComponent<AirplaneAttack>().setDamage(airplaneAttributes.basicDamage, airplaneAttributes.specialDamage);
        GetComponent<AirplaneScore>().score = gameState.score;
        healthHandler.setHealth(airplaneAttributes.maxHealth, gameState.health);
        healthHandler.onDead = () => {
            Debug.Log("Player Dead");
        };
    }

    // Called from GameController
    public void setAirplane(Airplane airplane, GameState gameState) {
        this.airplane = airplane;
        this.airplaneAttributes = airplane.attributes;
        this.gameState = gameState;
        this.gameState.health = (int) Mathf.Clamp(gameState.health, 0f, airplane.attributes.maxHealth);
        initAirplane();
    }


    private void OnCollisionEnter(Collision collision) {
        BaseFire fire = collision.collider.GetComponent<BaseFire>();
        if (fire != null && !fire.createBy.CompareTag(gameObject.tag)) {
            healthHandler.takdeDamage(fire.damage);
        }

        Collider collider = collision.collider;
        if (collider.CompareTag("Terrain")) {
            Debug.Log("Airplane dead");
        }
    }
}
