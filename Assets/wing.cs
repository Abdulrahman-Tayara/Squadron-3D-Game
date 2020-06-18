using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wing : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Vertical"))
        {
            GetComponent<TrailRenderer>().enabled = true;
        }
        else
        {
            //Color oldCol = GetComponent<Renderer> renderer.material.color;
            //Color newCol = new Color(oldCol.r, oldCol.g, oldCol.b, oldCol.a - 0.01f);
            //renderer.material.color = newCol;
            GetComponent<TrailRenderer>().enabled = false;
        }
    }
}
