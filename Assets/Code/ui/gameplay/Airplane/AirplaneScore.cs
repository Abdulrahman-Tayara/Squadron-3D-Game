using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AirplaneScore : MonoBehaviour {
    [HideInInspector]
    public int score;

    Observer<EnemyDeadEvent> enemyDead;

    void Start() {
        enemyDead = (enemyDeadEvent) => {
            score++;
        };
        EventBus<EnemyDeadEvent>.getInstance().register(enemyDead);
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnDestroy() {
        EventBus<EnemyDeadEvent>.getInstance().unregister(enemyDead);
    }

}
