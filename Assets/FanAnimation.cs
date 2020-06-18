using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FanAnimation : MonoBehaviour
{
    [SerializeField]
    private Transform fan;

    [SerializeField]
    private double rotationSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        fan.Rotate(0, (float)Math.Pow(rotationSpeed,10) * Time.deltaTime,0 );
    }
}
