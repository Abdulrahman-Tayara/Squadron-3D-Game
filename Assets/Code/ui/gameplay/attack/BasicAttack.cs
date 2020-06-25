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

    protected override void makeAttack() {
        BaseFire newBullet = createFire(bulletObject, transform.position + offset, transform.rotation);
        Rigidbody rigidbody = newBullet.GetComponent<Rigidbody>();
        Vector3 force = transform.forward * fireForce * Time.deltaTime;
        rigidbody.AddForce(force);
    }
}
