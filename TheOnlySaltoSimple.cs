using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheOnlySaltoSimple : MonoBehaviour
{
    //Rigidbody rb;
    public Transform Jpos;

    public bool OmSuelo;

    //public float FSalto = 250f;

    void Start()
    {
        Jpos = this.transform;
        //rb = GetComponent<Rigidbody>();

    }
    void Update()
    {
        RaycastHit sHit;
        OmSuelo = Physics.Raycast(this.Jpos.transform.position, -Jpos.up , out sHit, 2f);

        if (sHit.collider.gameObject.tag == "Walkable")
        {
            //Debug.Log(gameObject.tag);
            print("DEJA DE ESPERAR DE LOS DEMAS");
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    //rb.AddForce(Vector3.up * FSalto);
        //    Jpos.transform.Translate(new Vector3(0, FSalto * Time.deltaTime));
        //}
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawRay(this.Jpos.transform.position, -Jpos.up * 2f);
    }
}
