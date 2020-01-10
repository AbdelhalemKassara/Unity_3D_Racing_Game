using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputManager : MonoBehaviour
{
    public float throttle;
    public float steer;
    public float brake;
    public bool HeadLights;
    public bool ShiftUp;
    public bool ShiftDown;
    public bool CamView;
    public bool HandBrake;
    private string[] ConnectedCon;
    public bool GamePaused;

    void Update()// increase force down on the car when the velocity of the car goes up
    {
        ShiftUp = Input.GetButtonDown("ShiftUp");
        ShiftDown = Input.GetButtonDown("ShiftDown");
        HeadLights = Input.GetButtonDown("HeadLights");
        CamView = Input.GetButtonDown("CamView");
        HandBrake = Convert.ToBoolean(Input.GetAxis("HandBrake"));

        if (Input.GetButtonDown("Pause") == true)
        {
            GamePaused = !GamePaused;

        }

        ConnectedCon = Input.GetJoystickNames(); // gets the names of all the controllers and stores them in an array
        if (ConnectedCon.Length > 0 )// checks if something is stored in the array if something is stored it checks if it is blank 
        {//&& ConnectedCon[0] != ""
            throttle = Input.GetAxis("ThrottleTrigger");
            steer = Input.GetAxis("ConSteer");
            brake = Input.GetAxis("BrakeTrigger");

        }

        else
        {
            throttle = Input.GetAxis("ThrottleKey");
            steer = Input.GetAxis("buttonSteer");
            brake = Input.GetAxis("BrakeKey");

        }


    }

}
