using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SALSOSimple : MonoBehaviour
{
    Transform tr;
    Rigidbody rb;
    Vector3 salto;

    void Start()
    {
        tr = this.transform;
        rb = GetComponent<Rigidbody>();
    }

     
    void Update()
    {
       
        if (Input.GetButton("Jump"))
           // rb.AddForce( tr.up * 10f, ForceMode.Impulse);
            tr.Translate(0, 10f * Time.deltaTime, 0);

       
    }
}
