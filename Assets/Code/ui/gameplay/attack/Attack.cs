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
        fire.createBy = transform.root.gameObject;
        return fire;
    }

    abstract public void makeAttack();

    public void setDamage(float damage) {
        this.damage = damage;
    }
}
