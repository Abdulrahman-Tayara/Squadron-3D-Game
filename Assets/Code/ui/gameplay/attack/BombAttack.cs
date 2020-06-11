﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAttack : Attack {

    public float throwForce;
    public BaseFire fireObject;
    
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        base.update();
    }


    public override void makeAttack() {
        BaseFire newBomb = Instantiate(fireObject, transform.position + offset, transform.rotation);
        fireObject.damage = damage;
        Rigidbody rigidbody = newBomb.GetComponent<Rigidbody>();
        Vector3 force = (transform.forward - transform.up) * throwForce * Time.deltaTime;
        rigidbody.AddForce(force);
    }
}