﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiRollBar : MonoBehaviour
{
    public WheelCollider WheelL;
    public WheelCollider WheelR;
    private Rigidbody carRigidBody;
    public float AntiRoll = 50000f;
    void Start()
    {
        carRigidBody = GetComponent<Rigidbody>(); //gets the rigidbody of the car 
    }
    void FixedUpdate()
    {
        WheelHit hit = new WheelHit();
        float travelL = 1f;
        float travelR = 1f;

        bool groundedL = WheelL.GetGroundHit(out hit);//if the wheel is touching the ground

        if (groundedL)
        {
            travelL = (-WheelL.transform.InverseTransformPoint(hit.point).y - WheelL.radius) / WheelL.suspensionDistance;
        }

        bool groundedR = WheelR.GetGroundHit(out hit);

        if (groundedR)
        {
            travelR = (-WheelR.transform.InverseTransformPoint(hit.point).y - WheelR.radius) / WheelR.suspensionDistance;
        }

        var antiRollForce = (travelL - travelR) * AntiRoll;

        if (groundedL)
        {
            carRigidBody.AddForceAtPosition(WheelL.transform.up * -antiRollForce, WheelL.transform.position);
        }

        if (groundedR)
        {
            carRigidBody.AddForceAtPosition(WheelR.transform.up * antiRollForce, WheelR.transform.position);
        }
    }
}