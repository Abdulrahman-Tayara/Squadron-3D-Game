using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Code.utils;

public class HandleBoostEffect : MonoBehaviour
{
    [SerializeField]
    private Color colorAfterBoost;
    private Color normalColor;
    // Start is called before the first frame update
    void Start()
    {
        var v = gameObject.GetComponent<ParticleSystem>().main;
        normalColor = v.startColor.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(InputManager.geyKey(Key.BOOST)))
        {
            var v = gameObject.GetComponent<ParticleSystem>().main;
            v.startColor = colorAfterBoost;
            //new Color(1, 0.1568628f, 0, 1)
        }
        else
        {
            var v = gameObject.GetComponent<ParticleSystem>().main;
            v.startColor = normalColor;
            //new Color(1, 0.654902f, 0, 1)
        }
    }
}
