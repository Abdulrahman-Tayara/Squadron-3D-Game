using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthHandler : MonoBehaviour {

    public float maxHealth {
        private set; get;
    }

    [HideInInspector]
    public float currentHealth { private set; get; } = 100f;

    [HideInInspector]
    public bool isDead { private set; get; } = false;

    public Action onDead;

    public GameObject deadExplosion;
    public float deadExplosionTime = 2f;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (currentHealth <= 0f && !isDead) {
            if (onDead != null) {
                if (deadExplosion != null) {
                    GameObject explosion = Instantiate(deadExplosion, transform.position, transform.rotation);
                    Destroy(explosion.gameObject, deadExplosionTime);
                }
                isDead = true;
                onDead.Invoke();
            }
        }
    }

    // If currentHealth wasn't passed then set it as maxHealth
    public void setHealth(float maxHealth, float currentHealth = -1f) {
        this.maxHealth = maxHealth;
        this.currentHealth = currentHealth < 0f ? maxHealth : currentHealth;
    }

    public void takdeDamage(float damage) {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, currentHealth);
    }

}
