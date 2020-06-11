using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour {

    private EnemiesGenerator[] enemyGenerators;

    public int maxEnemies = 3;

    private  int lastGenerator = 0;

    private int currentEnemies = 0;

    private Enemy enemy = new Enemy(100f, 30f, 10f, 400f);

    void Start() {

    }

    
    void Update() {
        if (enemyGenerators == null || enemyGenerators.Length == 0) {
            enemyGenerators = GameObject.FindObjectsOfType<EnemiesGenerator>();
            return;
        }
        if (enemyGenerators.Length != 0 && currentEnemies < maxEnemies && Time.frameCount % 360 == 0) {
            generateEnemy();
        }
    }


    void generateEnemy() {
        enemyGenerators[lastGenerator].generateNewEnemy(enemy.clone());
        lastGenerator = (lastGenerator + 1) % enemyGenerators.Length;
        currentEnemies++;
    }
}
