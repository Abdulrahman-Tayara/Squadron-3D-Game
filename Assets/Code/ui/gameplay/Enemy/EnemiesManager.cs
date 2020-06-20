using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour {

    private EnemiesGenerator[] enemyGenerators;

    public int maxEnemies = 3;

    private int lastGenerator = 0;

    private int currentEnemies = 0;

    private Enemy enemy;

    private Observer<DifficultyChangedEvent> difficultyObserver;

    void Start() {
        EventBus<EnemyDeadEvent>.getInstance().register(enemyEvent => currentEnemies--);
        StartCoroutine(startGenerating());
        difficultyObserver = difficultyChanged;
        EventBus<DifficultyChangedEvent>.getInstance().register(difficultyObserver, true);
    }

    void Update() {
        if (enemyGenerators == null || enemyGenerators.Length == 0) {
            enemyGenerators = FindObjectsOfType<EnemiesGenerator>();
            return;
        }        
    }

    private void OnDestroy() {
        EventBus<DifficultyChangedEvent>.getInstance().unregister(difficultyObserver);
    }

    private void difficultyChanged(DifficultyChangedEvent difficultyChangedEvent) {
        Debug.Log("Diff : " + difficultyChangedEvent.difficulty);
        enemy = EnemyFactory.createEnemyByDifficulty(difficultyChangedEvent.difficulty);
    }

    private IEnumerator startGenerating() {
        while(true) {
            if (enemy != null && enemyGenerators != null && enemyGenerators.Length != 0 && currentEnemies < maxEnemies) {
                generateEnemy();
                yield return new WaitForSeconds(2);
            }
            yield return null;
        }
    }

    private void generateEnemy() {
        enemyGenerators[lastGenerator].generateNewEnemy(enemy.clone());
        lastGenerator = (lastGenerator + 1) % enemyGenerators.Length;
        currentEnemies++;
    }
}
