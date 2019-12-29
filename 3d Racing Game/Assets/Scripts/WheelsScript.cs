using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsScript : MonoBehaviour
{

    public WheelCollider fl;
    public WheelCollider fr;
    public WheelCollider rl;
    public WheelCollider rr;

    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        fl.motorTorque = -500;
        fr.motorTorque = 100;
        rr.motorTorque = 100;
        rl.motorTorque = -500;
    }
}
