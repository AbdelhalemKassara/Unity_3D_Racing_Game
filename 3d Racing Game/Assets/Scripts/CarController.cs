using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(LightingManager))]
public class CarController : MonoBehaviour
{
    public UIManager uim;
    public InputManager In; // 
                            // public means that the variable can be modified in unity menu 
    public List<WheelCollider> AllWheels; // gets all the wheels Wheelcollider
    public List<Transform> meshes;// gets the wheel meshes
    public List<WheelCollider> throttleWheels;// declairs a list of wheel colliders called throttleWheels
    public List<GameObject> steeringWheels;// declairs a list of steering wheel colliders called steeringWheels
    public List<WheelCollider> RearWheels;// 
    public float strengthCoefficient = 500f;// declairs a variable called strengthCoefficient and gives it a value of 20000, f means float
    public float BrakeStrength = 50f;// stores the break strength on each wheel
    public float maxTurn = 20f; // declairs a float called maxTurn and sets it to 20 (degrees)
    public Transform CM;// center of mass
    public Rigidbody rb;// rigid body
    public AudioSource audios;
    public AudioSource audioIdle;
    public LightingManager ln; // calles the lighting manager class
    public Transform carPosition; // stores the cars center position
    public List<GameObject> TailLights; // stores the tail lights (for lighting up the tail lights)
    public float[] GearRatio;
    public float FinalDriveRatio;// ratio from the end of the transmittion to the wheels
    private int CurGear = 1;// starts on the first gear (0 is reverse)
    public float MaxRpm;
    private float Rpm;
    private bool BrakeBool;

    void Start()
    {
        
        In = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody>();
        audios = GetComponent<AudioSource>();
        audioIdle = GetComponent<AudioSource>();

        if (CM)// checks to see if the object center of mass exists
        {
            rb.centerOfMass = CM.position - carPosition.position; // sets the center of mass
        }
    }
    void Update()
    {
       

        if (In.HeadLights)// if the button for turning on and off the headlights is pressed
        {
            ln.ToggleHeadLights(); // call this function
        }
        if (In.brake != 0)
        {
            BrakeBool = true;
        }
        else
        {
            BrakeBool = false;
        }
        foreach (GameObject tl in TailLights)// for each of the headlights it changes the color of them
        {
            tl.GetComponent<Renderer>().material.SetColor("_EmissionColor", BrakeBool ? new Color(.5f, 0.111f, 0.111f) : Color.black);
        }
        BrakeBool = false;

        if (In.ShiftUp && CurGear < GearRatio.Length - 1)// if the user has pressed the button to shift gears and the current gear is less than the total number of gears
        {
            CurGear++;// shift up one gear
        }
        if (In.ShiftDown && CurGear > 0)// if the user has pressed the button to shift gears down and the current gear is greater than zero
        {
            CurGear--;// shift down one gear
        }

        uim.ChangeText(transform.InverseTransformVector(rb.velocity).z * 3.6f, " KM/H", 0);//print the speed that the car is going in KM/H
        uim.ChangeText(Rpm, " RPM", 1); // print the current rpm of the engine on the screen
        uim.ChangeText(CurGear, "", 2);// print the current gear on the screen


    }

    //detect slip by getting the speed of the wheels and compare them to the speed of the car
    void FixedUpdate() // loop
    {
        bool Flag = true;
        Rpm = 0;// resests the rpm
        foreach (WheelCollider wheel in throttleWheels) // gets the wheel with the greatest rpm
        {
            if (wheel.rpm > Rpm)// if the current wheel's rpm is greater than the currently stored rpm  
            {
                Rpm = wheel.rpm;// set the wheel rpm equal to the current rpm
            }

            if (Flag)
            {
                Rpm = wheel.rpm;
                Flag = false;
            }


        }
        Rpm = Rpm * FinalDriveRatio * GearRatio[CurGear];
        Flag = true;

        foreach (WheelCollider wheel in throttleWheels) // for throttle torque and brake torque
        {


            wheel.brakeTorque = BrakeStrength * Time.deltaTime * In.brake * 10f;

            if (Rpm < MaxRpm && Rpm > -MaxRpm)
            {
                wheel.motorTorque = strengthCoefficient * FinalDriveRatio * GearRatio[CurGear] * Time.deltaTime * In.throttle *10f; // sets the torque of the wheel equal to (mulitply by Time.delatTime to get correct units (force/time(seconds)))
            }
            else
            {
                wheel.motorTorque = 0f;
            }

        }

        foreach (GameObject wheel in steeringWheels)
        {

            wheel.GetComponent<WheelCollider>().steerAngle = maxTurn * In.steer;
        }

        for (int i = 0; i < meshes.Count; i++)
        {
            AllWheels[i].GetWorldPose(out Vector3 Pos, out Quaternion quaternion); // gets the rotatation and positon of the wheel collider
            meshes[i].rotation = quaternion; // sets the rotation of the wheel equal to the roatation of the wheel collider
            meshes[i].position = Pos; // sets the position of the wheel equal to the positon of the wheel collider
        }

        foreach (WheelCollider wheel in RearWheels)
        {

            wheel.brakeTorque = BrakeStrength * Time.deltaTime * Convert.ToSingle(In.HandBrake) * 10f;
        }

        // audio 
        if (Rpm >= 2000f)
        {
            audios.pitch = (Rpm / MaxRpm);// change the pitch to depending on the rpm (audio file needs to be at max rpm)
        }
        else
        {
            audios.pitch = (2000f / MaxRpm);// change the pitch to depending on the rpm (audio file needs to be at max rpm)
        }
        if(In.GamePaused){

            audios.pitch = 0f;
        }


    }
    public float Engine()
    {
        //float speed = transform.InverseTransformVector(rb.velocity).z;

        return 0f;
    }
}
