using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour {

    [HideInInspector]
    public Transform fighterTransform;

    private HealthHandler healthHandler;

    public Enemy enemy { private set; get; }

    private void Awake() {
        healthHandler = GetComponent<HealthHandler>();
    }

    private void Update() {
        if (fighterTransform == null) {
            GameObject gameObject = GameObject.FindGameObjectWithTag("Airplane");
            if (gameObject != null)
                fighterTransform = gameObject.transform;
            return;
        }
    }


    public void setEnemy(Enemy enemy) {
        this.enemy = enemy;
        initEnemy();
    }

    private void initEnemy() {
        healthHandler.setHealth(enemy.health);
        healthHandler.onDead = () => {
            EventBus<EnemyDeadEvent>.getInstance().publish(new EnemyDeadEvent(enemy));
            Destroy(this.gameObject);
        };
    }

    private void OnCollisionEnter(Collision collision) {
        BaseFire fire = collision.collider.GetComponent<BaseFire>();
        if (fire != null && !fire.createdBy.CompareTag(gameObject.tag)) {
            healthHandler.takdeDamage(fire.damage);
        }
    }


}
