using Assets.Code.utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Attack : MonoBehaviour {
    [HideInInspector]
    public float damage;

    [Tooltip("Fire offset of the airplane position")]
    public Vector3 offset;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    protected virtual void update() {
        
    }

    abstract public void makeAttack();

    public void setDamage(float damage) {
        this.damage = damage;
    }
}
