using System.Collections.Generic;// using imports namespaces (namespaces are a collection of classes and other data types)
using UnityEngine;
using System;// for convert to single

[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(LightingManager))]//checks if the LightingManager is added if not it will be done automatically
public class oldcarcontroller : MonoBehaviour //this class inherits the MonoBehaviour class (Start, Update, FixedUpdate)
{

    public UIManager uim;
    public InputManager In; // 
                            // public means that the variable can be modified in unity menu 
    public List<WheelCollider> AllWheels; // gets all the wheels Wheelcollider //list is the same as an array but you can change the size of them
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
    public LightingManager ln; // calles the lighting manager class
    public Transform carPosition; // stores the cars center position
    public List<GameObject> TailLights; // stores the tail lights (for lighting up the tail lights)
    public float[] GearRatio;
    public float FinalDriveRatio;// ratio from the end of the transmittion to the wheels
    private int CurGear = 1;// starts on the first gear (0 is reverse)
    public float MaxRpm;
    public bool UseAutoTransmittion;
    private float Rpm;

    void Start()
    {
        In = GetComponent<InputManager>();//gets the input manager in this object
        rb = GetComponent<Rigidbody>();
        audios = GetComponent<AudioSource>();

        if (CM)// checks to see if the center of mass object exists
        {
            rb.centerOfMass = CM.position - carPosition.position; // sets the center of mass
        }
    }
    void Update()
    {
        headLights();
        tailLights();
        ShiftGears();
        updateUI();
    }

    //detect slip by getting the speed of the wheels and compare them to the speed of the car
    void FixedUpdate() // 
    {
        EngineRpm();// function that calculates the engine rpm
        AutoTransmittion(); // function that 
        Throttle();
        Breaking();
        Steering();
        MeshPosition();
        handBrake();
        EngineAudio();
    }

    public void EngineAudio()
    {
        if (In.GamePaused)
        {
            audios.pitch = 0f;// changes the pitch of the engine to 0
        }
        else
        {
            if (Rpm >= 2000f)
            {
                audios.pitch = (Rpm / MaxRpm);// change the pitch to depending on the rpm (audio file needs to be at max rpm)
            }
            else
            {
                audios.pitch = (2000f / MaxRpm);// change the pitch to depending on the rpm (audio file needs to be at max rpm)
            }

        }
    }

    public void EngineRpm()
    {
        bool Flag = true;
        foreach (WheelCollider wheel in throttleWheels) // gets the wheel with the greatest rpm
        {
            if (Flag)
            {
                Rpm = wheel.rpm;// gets the first wheels rpm
                Flag = false;
            }
            else
            {
                if (wheel.rpm > Rpm)// if the current wheel's rpm is greater than the currently stored rpm  
                {
                    Rpm = wheel.rpm;// set the wheel rpm equal to the current rpm
                }
            }
        }
        Rpm = Rpm * FinalDriveRatio * GearRatio[CurGear];// gets the engine rpm
    }
    public void AutoTransmittion()
    {
        if (UseAutoTransmittion)//if the user wants to use the automatic transmittion
        {
            if (Rpm < MaxRpm - 3000f && CurGear > 1)// checks if the rpm is less than the minimum and the current gear is greater than the first gear
            {
                CurGear--;// goes down one gear

            }
            if (Rpm > MaxRpm && CurGear != 0 && CurGear < 5)//checks if the rpm is greater than the maximum and if the gear is not in reverse and is less than 5
            {
                CurGear++;// goes up by one gear
            }
        }
    }
    public void tailLights()
    {
        foreach (GameObject tl in TailLights)// for each of the headlights it changes the color of them
        {
            tl.GetComponent<Renderer>().material.SetColor("_EmissionColor", Convert.ToBoolean(In.brake) ? new Color(.5f, 0.111f, 0.111f) : Color.black);//
        }


    }
    public void headLights()
    {
        if (In.HeadLights)// if the button for turning on and off the headlights is pressed
        {
            ln.ToggleHeadLights(); // call this function
        }
    }
    public void updateUI()
    {
        uim.ChangeText(transform.InverseTransformVector(rb.velocity).z * 3.6f, " KM/H", 0);//print the speed that the car is going in KM/H
        uim.ChangeText(Rpm, " RPM", 1); // print the current rpm of the engine on the screen
        uim.ChangeText(CurGear, "", 2);// print the current gear on the screen
    }
    public void ShiftGears()
    {
        if (In.ShiftUp && CurGear < GearRatio.Length - 1)// if the user has pressed the button to shift gears and the current gear is less than the total number of gears
        {
            CurGear++;// shift up one gear
        }
        if (In.ShiftDown && CurGear > 0)// if the user has pressed the button to shift gears down and the current gear is greater than zero
        {
            CurGear--;// shift down one gear
        }

    }
    public void Steering()
    {
        foreach (GameObject wheel in steeringWheels)//loops through each of the steering wheels 
        {

            wheel.GetComponent<WheelCollider>().steerAngle = maxTurn * In.steer;//in the wheel object in the wheelcollider make the steerAngle equal to the maxTurn multiplied by the Input 
        }

    }
    public void MeshPosition()
    {
        for (int i = 0; i < meshes.Count; i++)
        {
            AllWheels[i].GetWorldPose(out Vector3 Pos, out Quaternion quaternion); // gets the rotatation and positon of the wheel collider
            meshes[i].rotation = quaternion; // sets the rotation of the wheel equal to the roatation of the wheel collider
            meshes[i].position = Pos; // sets the position of the wheel equal to the positon of the wheel collider
        }
    }
    public void handBrake()
    {
        foreach (WheelCollider wheel in RearWheels)
        {

            wheel.brakeTorque = BrakeStrength * Time.deltaTime * Convert.ToSingle(In.HandBrake);// converts a boolean to a float
        }
    }
    public void Breaking()
    {
        foreach (WheelCollider wheel in throttleWheels)
        {
            wheel.brakeTorque = BrakeStrength * Time.deltaTime * In.brake;
        }
    }
    public void Throttle()
    {
        foreach (WheelCollider wheel in throttleWheels) // loops through each of the throttle and brake wheels
        {
            if (Rpm < MaxRpm && Rpm > -MaxRpm)
            {
                wheel.motorTorque = strengthCoefficient * FinalDriveRatio * GearRatio[CurGear] * Time.deltaTime * In.throttle; // sets the torque of the wheel equal to (mulitply by Time.delatTime to get correct units (force/time(seconds)))
            }
            else
            {
                wheel.motorTorque = 0f;//set the wheel torque to 0 
            }
        }

    }
    public float EngineCurve(float rpm)
    {
        return 0f;
    }
    public float BrakeCurve()
    {
        return 0f;
    }
    public float Differential()
    {
        return 0f;
    }
}
