using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularMissileFire : BaseFire
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

    [Tooltip("The prefab of the explosion")]
    [SerializeField]
    private GameObject explosion;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Fire"))
            return;
        GameObject explosionPrefab = Instantiate(explosion, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearBy in colliders)
        {
            Rigidbody rb = nearBy.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, radius);
            }
        }
        Destroy(explosionPrefab.gameObject, prefabPlayDuration);
        Destroy(gameObject);
    }
}
