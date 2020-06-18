using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFire : MonoBehaviour {
    [HideInInspector]
    public float damage;
    
    public GameObject createBy;

    private void OnCollisionEnter(Collision collision) {
        
    }
}
