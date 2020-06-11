using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollowsAirplane : MonoBehaviour {

    private Transform airplane;

    [Tooltip("Distance between the ariplane and the camera")]
    public float cameraOffset;
    public float cameraHeightOffset;

    void Start() {

    }

    // Update is called once per frame
    void FixedUpdate() {
        if (airplane == null) {
            findAirplane();
            return;
        }

        Vector3 moveCamerTo = airplane.transform.position
            - airplane.transform.forward * cameraOffset // distance offset
            + Vector3.up * cameraHeightOffset; // height offset

        transform.position = moveCamerTo;
        transform.LookAt(airplane.position);
    }

    private void findAirplane() {
        GameObject gameObject = GameObject.FindGameObjectWithTag("Airplane");
        airplane = gameObject != null ? gameObject.transform : null;
    }
}
