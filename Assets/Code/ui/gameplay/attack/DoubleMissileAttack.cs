using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleMissileAttack : Attack
{
    private int turn;


    private GameObject[] missileAttacks;

    public void Start()
    {
        missileAttacks = GameObject.FindGameObjectsWithTag("MissileAttack");
    }
    protected override void makeAttack() {
        Attack missileLauncher1 = missileAttacks[turn].GetComponent<Attack>();
        missileLauncher1.damage = damage;
        missileLauncher1.attack();
        turn = (turn + 1) % missileAttacks.Length;
    }

}
