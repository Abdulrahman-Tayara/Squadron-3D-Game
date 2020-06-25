using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissileAttack : Attack
{
    [SerializeField]
    private GameObject throwPoint;
    [SerializeField]
    private BaseFire rocketPrefab;
    [SerializeField]
    private string targetTag;

    private Transform airplane;

    public float lifeTime = 4;

    private float nextTimeToFire;

    [SerializeField]
    private float fireRate = 5f;

    public void Start()
    {
        airplane = transform.root;
    }

    protected override void makeAttack()
    {
        if (Time.time < nextTimeToFire)
            return;
        nextTimeToFire = Time.time + 1f / fireRate;
        GameObject nearest = null;
        GameObject[] objects = GameObject.FindGameObjectsWithTag(targetTag);
        foreach (GameObject item in objects)
        {
            if (item.GetComponent<Renderer>().isVisible)
            {
                if (nearest == null)
                {
                    nearest = item;
                    continue;
                }
                if (Vector3.Distance(airplane.position, item.transform.position)
                            <= Vector3.Distance(airplane.position, nearest.transform.position))
                {
                    nearest = item;
                }
            }
        }
        if (nearest != null)
        {
            BaseFire temp = createFire(rocketPrefab, throwPoint.transform.position, transform.rotation);
            temp.GetComponent<HomingMissileFire>().target = nearest.transform;
            Destroy(temp.gameObject, lifeTime);
        }
    }
}
