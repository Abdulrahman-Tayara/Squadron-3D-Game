using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleGunAttack : Attack {


    private GunAttack gun1, gun2;

    private void Start() {
        gun1 = transform.Find("leftGun").GetComponent<GunAttack>();
        gun1.damage = damage;
        gun2 = transform.Find("rightGun").GetComponent<GunAttack>();
        gun2.damage = damage;
    }

    public override void makeAttack() {        
        gun1.makeAttack();
        gun2.makeAttack();
    }
}
