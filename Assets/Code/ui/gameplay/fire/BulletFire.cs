using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : BaseFire
{
    public GameObject imbactEffect;

    private void Start() {
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject imbact = Instantiate(imbactEffect, transform.position, Quaternion.LookRotation(collision.contacts[0].normal));
        Destroy(imbact, 2f);
        Destroy(gameObject);
    }
}
