using Assets.Code.utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneAttack : MonoBehaviour {

    public Attack basicAttack;
    public Attack specialAttack;

    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (basicAttack != null) {
            if (Input.GetKey(InputManager.geyKey(Key.BASIC_FIRE))) {
                basicAttack.makeAttack();
            }
        }

        if (specialAttack != null) {
            if (Input.GetKeyDown(InputManager.geyKey(Key.SPECIAL_FIRE))) {
                specialAttack.makeAttack();
            }
        }
    }

    public void setDamage(float basicDamage, float specialDamage) {
        if (basicAttack != null)
            basicAttack.damage = basicDamage;
        if (specialAttack != null)
            specialAttack.damage = specialDamage;
    }
}
