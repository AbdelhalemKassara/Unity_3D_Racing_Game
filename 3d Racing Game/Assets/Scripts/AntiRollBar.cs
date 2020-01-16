using UnityEngine;// imports the namespace called UnityEngine (namespace are collection of related classes and data)

public class AntiRollBar : MonoBehaviour//this class derives from the MonoBehaviour class
{
    public WheelCollider WheelL;//creates a new variable for the left wheelcollider
    public WheelCollider WheelR;//creates a new variable for the right wheelcollider
    private Rigidbody carRigidBody;//
    public float AntiRoll = 50000f;// default antiroll force applied
    void Start()
    {
        carRigidBody = GetComponent<Rigidbody>(); //gets the rigid body of this object (the car frame) 
    }
    void FixedUpdate()//used for physics calculations
    {
        WheelHit hit = new WheelHit();// WheelHit contains information from the wheelcollider
        float travelL = 1f;//declairs new variables 
        float travelR = 1f;
        //if car is grounded it is not out of the range 1-0
        bool groundedL = WheelL.GetGroundHit(out hit);//if the left wheel is touching another object it returns true  and gets data about the wheel and stores it in hit
        if (groundedL)
        {//hit.point is the point of contact with the ground
            travelL = (-WheelL.transform.InverseTransformPoint(hit.point).y - WheelL.radius) / WheelL.suspensionDistance;//gets the position of the wheel from the point it is touching the ground and subtracts the wheel radius to get the center of the wheel the divides it by the suspention distance to get the value to be inbetween 1 and zero (1 fully extended , 0 full compressed)

        }
        bool groundedR = WheelR.GetGroundHit(out hit);// if the right wheel is touching another object it returns true

        if (groundedR)
        {
            travelR = (-WheelR.transform.InverseTransformPoint(hit.point).y - WheelR.radius) / WheelR.suspensionDistance;

        }

        var antiRollForce = (travelL - travelR) * AntiRoll;// gets the difference in position then multiplies that by the antiroll force
        if (groundedL)
        {
            carRigidBody.AddForceAtPosition(WheelL.transform.up * -antiRollForce, WheelL.transform.position);//multiplies the force with the positon of the wheel,applies the force on the center of the wheel
        }
        if (groundedR)
        {
            carRigidBody.AddForceAtPosition(WheelR.transform.up * antiRollForce, WheelR.transform.position);
        }
    }
}