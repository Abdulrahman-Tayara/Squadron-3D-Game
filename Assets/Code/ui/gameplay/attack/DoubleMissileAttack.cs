using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleMissileAttack : Attack
{
    private float nextTimeToFire;

    [SerializeField]
    private float fireRate = 5f;

    private float turn;

    public override void makeAttack() {
        if (Time.time < nextTimeToFire && turn == 0)
            return;
        nextTimeToFire = Time.time + 1f / fireRate;
        if (turn == 0) {
            MissileAttack missileLauncher1 = transform.Find("missileLauncher_1").GetComponent<MissileAttack>();
            missileLauncher1.damage = damage;
            missileLauncher1.makeAttack();
        } else {
            MissileAttack missileLauncher4 = transform.Find("missileLauncher_4").GetComponent<MissileAttack>();
            missileLauncher4.damage = damage;
            missileLauncher4.makeAttack();
        }
        turn = 1 - turn;
    }

}
