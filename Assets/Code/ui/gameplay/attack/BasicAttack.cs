using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : Attack {

    public BaseFire bulletObject;
    public float fireForce;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
    }

    public override void makeAttack() {
        BaseFire newBullet = Instantiate(bulletObject, transform.position + offset, transform.rotation);
        newBullet.damage = damage;
        Rigidbody rigidbody = newBullet.GetComponent<Rigidbody>();
        Vector3 force = transform.forward * fireForce * Time.deltaTime;
        rigidbody.AddForce(force);
    }
}
