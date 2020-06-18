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

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (currentHealth <= 0f && !isDead) {
            if (onDead != null) {
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
    }

}
