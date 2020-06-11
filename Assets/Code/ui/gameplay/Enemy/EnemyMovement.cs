using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    private Transform fighterPosition;
    public CharacterController controller;
    public Rigidbody rb;
    [HideInInspector]
    public float speed;
    [HideInInspector]
    public float dangerZone = 400f;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    private void HandleFollowingPlayer() {
        followTheFighter(canFollow() ? speed : speed * 0.5f);
    }
    void FixedUpdate() {
        if (fighterPosition == null) {
            fighterPosition = GameObject.FindGameObjectWithTag("Airplane").transform;
            return;
        }
        HandleFollowingPlayer();

    }

    private void followTheFighter(float speed) {
        transform.LookAt(fighterPosition.position);
        Vector3 Moveto = transform.forward * this.speed * Time.deltaTime;
        controller.Move(Moveto);
    }

    private bool canFollow() {
        Vector3 distance = transform.position - fighterPosition.position;
        return distance.magnitude <= dangerZone;
    }
}
