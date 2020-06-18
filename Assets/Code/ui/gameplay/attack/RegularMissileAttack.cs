using UnityEngine;

public class RegularMissileAttack : Attack
{
    [SerializeField]
    private float throwForce = 350f;

    private float nextTimeToFire;

    [Range(1f, 5f)]
    [SerializeField]
    private float rocketLifeTime = 3f;

    [SerializeField]
    private Vector3 rocketRotation;


    [Space]

    [SerializeField]
    private GameObject throwPoint;
    [SerializeField]
    private BaseFire rocketPrefab;

    public override void makeAttack()
    {
        //*Quaternion.Euler(rocketRotation)
        BaseFire temp = createFire(rocketPrefab, throwPoint.transform.position, transform.rotation * Quaternion.Euler(rocketRotation));
       // temp.transform.rotation = Quaternion.LookRotation(-transform.forward);
        Rigidbody rb = temp.GetComponent<Rigidbody>();
        if (rb != null)
            rb.AddForce(Quaternion.AngleAxis(rocketRotation.y, transform.up) * transform.forward * throwForce, ForceMode.VelocityChange);
        Destroy(temp.gameObject, rocketLifeTime);
    }
}
