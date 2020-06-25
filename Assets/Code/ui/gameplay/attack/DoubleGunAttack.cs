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

    protected override void makeAttack() {
        foreach (var item in guns)
        {
            item.GetComponent<GunAttack>().attack();
        }
    }
}
