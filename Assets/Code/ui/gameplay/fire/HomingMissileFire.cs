using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissileFire : BaseFire
{

    [Tooltip("Radius of the explosion")]
    [SerializeField]
    private float radius = 5f;

    [Tooltip("The force caused by the explosion")]
    [SerializeField]
    private float explosionForce = 200f;

    [Tooltip("The length of time the effect will appear")]
    [SerializeField]
    private float prefabPlayDuration = 2f;

    [Tooltip("The speed movement of the missile")]
    [SerializeField]
    private float speed = 200f;

    [SerializeField]
    private float turn = 20f;

    [Tooltip("The prefab of the explosion")]
    [SerializeField]
    private GameObject explosion;

    private Rigidbody rb;

    [HideInInspector]
    public Transform target;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (target == null)
            return;
        rb.velocity = transform.forward * speed;
        var rocketTargetRotation = Quaternion.LookRotation(target.position - transform.position);
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rocketTargetRotation, turn));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Fire"))
            return;
        GameObject temp = Instantiate(explosion, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearBy in colliders)
        {
            Rigidbody rb = nearBy.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, radius);
            }
        }
        Destroy(temp.gameObject, prefabPlayDuration);
        Destroy(gameObject);
    }
}
