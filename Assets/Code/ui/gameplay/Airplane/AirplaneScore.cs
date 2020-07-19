using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AirplaneScore : MonoBehaviour {
    [HideInInspector]
    public int score, coins;
    
    Observer<EnemyDeadEvent> enemyDead;

    void Start() {
        enemyDead = (enemyDeadEvent) => {
            score++;
            coins = score / 3;
        };
        EventBus<EnemyDeadEvent>.getInstance().register(enemyDead);
    }

    // Update is called once per frame
    void Update() {

    }

    public void setData(int score, int coins) {
        this.score = score;
        this.coins = coins;
    }

    private void OnDestroy() {
        EventBus<EnemyDeadEvent>.getInstance().unregister(enemyDead);
    }

}
