using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileFire : BaseFire
{
    [Tooltip("Radius of the explosion")]
    [SerializeField]
    private float radius = 5f;

    [Tooltip("The force caused by the explosion")]
    [SerializeField]
    private float Force = 200f;

    [Tooltip("The length of time the effect will appear")]
    [SerializeField]
    private float prefabPlayDuration = 2f;

    [Tooltip("The prefab of the explosion")]
    [SerializeField]
    private GameObject Explosion;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Fire"))
            return;
        GameObject temp = Instantiate(Explosion, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearBy in colliders)
        {
            Rigidbody rb = nearBy.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(Force, transform.position, radius);
            }
        }
        Destroy(temp.gameObject, prefabPlayDuration);
        Destroy(gameObject);
    }
}
