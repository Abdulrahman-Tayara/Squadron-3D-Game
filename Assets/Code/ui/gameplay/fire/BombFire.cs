using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFire : BaseFire {
    public float delay = 3f;
    public float countdown;
    public bool hasExploded = false;
    public float radius = 5f;
    public float Force = 5f;
    public GameObject Explosion;
    public float effectDuration = 2f;
    // Start is called before the first frame update
    void Start() {
        countdown = delay;
    }

    // Update is called once per frame
    void Update() {
        //countdown -= Time.deltaTime;
        //if (countdown <= 0f && !hasExploded) {
        //    Explode();
        //    hasExploded = true;
        //}
    }

    public void Explode() {
        GameObject temp = Instantiate(Explosion, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearBy in colliders) {
            Rigidbody rb = nearBy.GetComponent<Rigidbody>();
            if (rb != null) {
                rb.AddExplosionForce(Force, transform.position, radius);
            }
        }
        Destroy(temp, 4);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision) {
        ContactPoint contact = collision.contacts[0];
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 position = contact.point;
        GameObject temp = Instantiate(Explosion, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearBy in colliders) {
            Rigidbody rb = nearBy.GetComponent<Rigidbody>();
            if (rb != null) {
                rb.AddExplosionForce(Force, transform.position, radius);
            }
        }
        Destroy(temp, effectDuration);
        Destroy(gameObject);
    }
}
