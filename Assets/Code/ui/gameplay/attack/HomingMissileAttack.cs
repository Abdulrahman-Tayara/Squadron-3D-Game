using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissileAttack : Attack
{
    [SerializeField]
    private GameObject throwPoint;
    [SerializeField]
    private BaseFire rocketPrefab;

    private Transform airplane;
    public void Start()
    {
        airplane = GameObject.FindGameObjectWithTag("Airplane").transform;
    }

    public override void makeAttack()
    {
        GameObject nearest = null;
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");
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
        }
    }
}
