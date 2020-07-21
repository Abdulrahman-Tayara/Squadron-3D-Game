using Assets.Code.utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Attack : MonoBehaviour {
    [HideInInspector]
    public float damage;

    [Tooltip("Fire offset of the airplane position")]
    public Vector3 offset;
    [HideInInspector]
    public GameObject attacker;

    // Start is called before the first frame update
    void Start() {
        attacker = transform.root.gameObject;
        if (attacker == null)
            Debug.Log("attacker is null");
    }

    protected BaseFire createFire(BaseFire baseFire, Vector3 position, Quaternion rotation) {
        BaseFire fire = Instantiate(baseFire, position, rotation);
        fire.damage = damage;
        fire.createdBy = transform.root.gameObject;
        ignoreCollideWithAirplane(fire);
        return fire;
    }

    protected void ignoreCollideWithAirplane(BaseFire fire) {
        Collider[] collidersInAirplane = transform.root.GetComponentsInChildren<Collider>();
        Collider[] collidersInFire = fire.transform.root.GetComponentsInChildren<Collider>();
        foreach (var item1 in collidersInAirplane) {
            foreach (var item2 in collidersInFire) {
                Physics.IgnoreCollision(item1, item2, true);
            }
        }
    }

    public void attack() {
        if (!PauseManager.isPaused)
            makeAttack();
    }

    abstract protected void makeAttack();

    public void setDamage(float damage) {
        this.damage = damage;
    }
}
