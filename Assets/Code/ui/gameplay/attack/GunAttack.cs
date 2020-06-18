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
    private float throwForce = 600f;

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

    private AudioSource sound;

    public void Start()
    {
        sound = transform.GetComponent<AudioSource>();
    }


    public override void makeAttack() {
        if (Time.time < nextTimeToFire)
            return;
        nextTimeToFire = Time.time + 1f / fireRate;
        muzzleFlash.Play();
        if(sound != null && !sound.isPlaying)
        {
            sound.Play();
        }
        //90f, -7f, 0f
        BaseFire bullet = createFire(bulletPrefab, firePosition.transform.position, transform.rotation * Quaternion.Euler(bulletRotation));
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null) {
            bulletRb.AddForce(Quaternion.AngleAxis(bulletRotation.y, transform.up) * transform.forward * throwForce, ForceMode.VelocityChange);
        }

        Destroy(bullet.gameObject, bulletLifetime);
    }
}