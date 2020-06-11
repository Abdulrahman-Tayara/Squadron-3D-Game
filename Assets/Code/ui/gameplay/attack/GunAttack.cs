using UnityEngine;

public class GunAttack : Attack {

    [Tooltip("Range that the gun's bullet can cause damage")]
    [SerializeField]
    private float range = 100f;

    [SerializeField]
    private float impactForce = 30f;

    [SerializeField]
    private float fireRate = 15;

    private float nextTimeToFire = 0f;

    [SerializeField]
    private float throwForce = 70f;

    [SerializeField]
    private Vector3 bulletRotation;

    [SerializeField]
    [Range(1f, 5f)]
    private float bulletLifetime = 3f;

    [Space]
    [Space]

    [Header("Objects and prefabs")]
    [Tooltip("Where the bullet will start from")]
    [SerializeField]
    private GameObject firePosition;

    [SerializeField]
    private ParticleSystem muzzleFlash;

    [SerializeField]
    private BaseFire bulletPrefab;


    public override void makeAttack() {
        if (Time.time < nextTimeToFire)
            return;
        nextTimeToFire = Time.time + 1f / fireRate;
        muzzleFlash.Play();
        //90f, -7f, 0f
        BaseFire bullet = Instantiate(bulletPrefab, firePosition.transform.position, transform.rotation * Quaternion.Euler(bulletRotation));
        bullet.damage = damage;
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null) {
            bulletRb.AddForce(Quaternion.AngleAxis(bulletRotation.y, transform.up) * transform.forward * throwForce, ForceMode.VelocityChange);
        }
        Destroy(bullet.gameObject, bulletLifetime);

        RaycastHit hit;
        //check if the target is in the gun range
        if (Physics.Raycast(transform.position, transform.forward, out hit, range)) {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null) {
                target.takeDamage(damage);
            }
            if (hit.rigidbody != null) {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
    }
}