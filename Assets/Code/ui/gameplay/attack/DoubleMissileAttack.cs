using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleMissileAttack : Attack
{
    private float nextTimeToFire;

    [SerializeField]
    private float fireRate = 5f;

    private int turn;


    private GameObject[] missileAttacks;

    public void Start()
    {
        missileAttacks = GameObject.FindGameObjectsWithTag("MissileAttack");
    }
    public override void makeAttack() {
        if (Time.time < nextTimeToFire && turn == 0)
            return;
        nextTimeToFire = Time.time + 1f / fireRate;
        Attack missileLauncher1 = missileAttacks[turn].GetComponent<Attack>();
        missileLauncher1.damage = damage;
        missileLauncher1.makeAttack();
        turn++;
        if (turn >= missileAttacks.Length)
            turn = 0;
    }

}
