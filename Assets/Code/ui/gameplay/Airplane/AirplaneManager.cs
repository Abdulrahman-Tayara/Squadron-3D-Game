using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneManager : MonoBehaviour {

    private Airplane airplane;
    private Airplane.AirplaneAttributes airplaneAttributes;
    private GameState gameState;
    private HealthHandler healthHandler;
    public bool isDead { private set; get; } = false;

    private void Awake() {
        healthHandler = GetComponent<HealthHandler>();
    }

    private void initAirplane() {
        GetComponent<AirplaneMovment>().setSpeedValues(airplaneAttributes.speed, airplaneAttributes.minSpeed, airplaneAttributes.maxSpeed);
        GetComponent<AirplaneAttack>().setDamage(airplaneAttributes.basicDamage, airplaneAttributes.specialDamage);
        GetComponent<AirplaneScore>().setData(gameState.score, gameState.coins);
        healthHandler.setHealth(airplaneAttributes.maxHealth, gameState.health);
        healthHandler.onDead = () => {
            isDead = true;
            airplaneDead();
        };
    }

    private void airplaneDead() {
        EventBus<AirplaneDeadEvent>.getInstance().publish(new AirplaneDeadEvent(airplane));
        Destroy(gameObject);
    }

    // Called from GameController
    public void setAirplane(Airplane airplane, GameState gameState) {
        this.airplane = airplane;
        this.airplaneAttributes = airplane.attributes;
        this.gameState = gameState;
        this.gameState.health = (int) Mathf.Clamp(gameState.health, 0f, airplane.attributes.maxHealth);
        initAirplane();
    }

    public float getCurrentHealth() {
        return healthHandler.currentHealth;
    }

    public int getCurrentScore() {
        return GetComponent<AirplaneScore>().score;
    }

    private void OnCollisionEnter(Collision collision) {
        Collider collider = collision.collider;
        BaseFire fire = collider.GetComponent<BaseFire>();
        if (fire != null && !fire.createdBy.CompareTag(gameObject.tag)) {
            healthHandler.takdeDamage(fire.damage);
        }
        if (collider.CompareTag("Terrain")) {
            healthHandler.takdeDamage(10f);
        }
    }
}
