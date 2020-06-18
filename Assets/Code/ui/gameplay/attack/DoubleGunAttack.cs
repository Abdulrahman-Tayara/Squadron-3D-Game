using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Code.utils;

public class DoubleGunAttack : Attack {


    private GameObject[] guns;
    private Transform airPlane;

    private void Start() {
        guns = GameObject.FindGameObjectsWithTag("GunAttack");
    }

    public override void makeAttack() {
        foreach (var item in guns)
        {
            item.GetComponent<GunAttack>().makeAttack();
        }
    }
}
