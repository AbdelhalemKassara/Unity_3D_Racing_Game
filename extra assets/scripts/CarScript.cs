using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
   
    public Rigidbody rb; // declairs a Rigidbody called rb

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //
    }

    void Update()
    {
//        rb.AddForce(0,0,10000);
    }
}
