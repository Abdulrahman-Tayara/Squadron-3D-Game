using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayedMissile : MonoBehaviour
{
    [Tooltip("Time delay before the bomb explodes")]
    [SerializeField]
    private float delay = 3f;

    private float countdown;

    private bool hasExploded = false;

    [Tooltip("Radius of the explosion")]
    [SerializeField]
    private float radius = 5f;

    [Tooltip("The force caused by the explosion")]
    [SerializeField]
    private float Force = 200f;

    [Tooltip("The prefab of the explosion")]
    [SerializeField]
    private GameObject Explosion;

    [Tooltip("The length of time the effect will appear")]
    [SerializeField]
    private float prefabPlayDuration = 2f;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    public void Explode()
    {
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
        Destroy(temp, prefabPlayDuration);
        Destroy(gameObject);
    }
}
