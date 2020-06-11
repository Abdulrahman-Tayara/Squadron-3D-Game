using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    // Start is called before the first frame update
    public Attack attack;

    void Start() {
        attack = transform.Find("rightGun").GetComponent<GunAttack>();
    }

    // Update is called once per frame
    void Update() {
        attack.makeAttack();
    }
}
