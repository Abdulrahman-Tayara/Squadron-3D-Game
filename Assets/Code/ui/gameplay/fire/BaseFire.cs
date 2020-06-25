using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFire : MonoBehaviour {
    [HideInInspector]
    public float damage;
    
    public GameObject createdBy;

    private void OnCollisionEnter(Collision collision) {
        
    }
}
