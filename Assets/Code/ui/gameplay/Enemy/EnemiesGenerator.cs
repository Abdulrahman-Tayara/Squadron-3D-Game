﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesGenerator : MonoBehaviour {

    public GameObject enemyObject;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void generateNewEnemy(Enemy enemy) {
        GameObject newEnemy = Instantiate(enemyObject, transform.position, transform.rotation);
        newEnemy.GetComponent<EnemyManager>().setEnemy(enemy);
    }
}
