using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    private EnemyManager manager;

    public CharacterController controller;
    public Rigidbody rb;
    public GameObject[] moveSpots;


    private float speed, dangerZone;
    private Enemy enemy;

    private int targetSpot = -1; // moveSpot index

    private void Awake() {
        manager = GetComponent<EnemyManager>();
    }

    private void Start() {
        StartCoroutine(startMove());
    }

    private void Update() {
        if (moveSpots == null || moveSpots.Length == 0)
            moveSpots = GameObject.FindGameObjectsWithTag("EnemyMoveSpot");
        enemy = manager.enemy;
        speed = enemy != null ? enemy.speed : 0f;
        dangerZone = enemy != null ? enemy.dangerZone : 0f;
    }

    private IEnumerator startMove() {
        while (true) {
            checkTerrainCollision();
            if (canFollow()) // can follow the fighter
                chaseTheFighter(speed);
            else if (moveSpots != null && moveSpots.Length > 0) {
                patrolMove();
            }
            yield return null;
        }
    }

    private void chaseTheFighter(float speed) {
        transform.LookAt(manager.fighterTransform.position);
        Vector3 Moveto = transform.forward * speed * Time.deltaTime;
        controller.Move(Moveto);
    }

    private void patrolMove() {
        if (targetSpot == -1)
            targetSpot = Random.Range(0, moveSpots.Length);
        else if (Vector3.Distance(transform.position, moveSpots[targetSpot].transform.position) < 0.2f) { // enemy reached to the spot
            targetSpot = (targetSpot + 1) % moveSpots.Length;
        }
        if (!canFollow())
            goToSpot(targetSpot, speed);
    }

    private void goToSpot(int targetSpot, float speed) {
        if (targetSpot < 0 || targetSpot > moveSpots.Length)
            return;
        transform.LookAt(moveSpots[targetSpot].transform.position);
        Vector3 moveTo = transform.forward * speed * Time.deltaTime;
        controller.Move(moveTo);
    }

    private void checkTerrainCollision() {
        if (Terrain.activeTerrain != null) {
            float height = Terrain.activeTerrain.SampleHeight(transform.position);
            if (height > transform.position.y) {
                transform.position = new Vector3(transform.position.x, height, transform.position.z);
            }
        }

    }

    public bool canFollow() {
        return manager.fighterTransform != null &&
            Vector3.Distance(transform.position, manager.fighterTransform.position) <= dangerZone;
    }
}
