using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    private EnemyManager enemyManager;

    public Attack attack;

    private float dangerZone;
    private void Awake() {
        enemyManager = GetComponent<EnemyManager>();
    }

    void Start() {
        attack = transform.Find("rightGun").GetComponent<GunAttack>();
    }

    // Update is called once per frame
    void Update() {
        if (enemyManager.fighterTransform == null) {
            return;
        }
        attack.damage = enemyManager.enemy != null ? enemyManager.enemy.damage : 0f;
        dangerZone = enemyManager.enemy != null ? enemyManager.enemy.dangerZone : 0f;
        if (canAttack())
            attack.makeAttack();
    }

    private bool canAttack() {
        return Vector3.Distance(transform.position, enemyManager.fighterTransform.position) <= dangerZone;
    }
}
