﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSelect : MonoBehaviour
{
    private bool once = false;
   // [HideInInspector]
    public int CarIndex;
    public List<GameObject> cars;
    public GameObject CarSelectMenu;
    [HideInInspector]
    public GameObject SelectedCar;
    public Dropdown CarDropDown;

    void Awake()//runs before the start loop
    {
         if (CarIndex <= cars.Count - 1)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                cars[i].SetActive(false);
            }
            SelectedCar = cars[CarIndex];
            cars[CarIndex].SetActive(true);
        }
        else
        {
            Debug.Log("Index is not selected or valid");
        }


    }
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
    public void SelectCar(int Index)
    {
        SelectedCar = cars[CarIndex];       
    }

    // Update is called once per frame
    void stuff()
    {
        Debug.Log(cars[1].name);
        List<string> CarOptions = new List<string>();
        for (int i = 0; i < cars.Count; i++)
        {
            CarOptions.Add(cars[i].name);//get object name
        }
        CarDropDown.AddOptions(CarOptions);

        CarDropDown.RefreshShownValue();


    }
    void Pause()
    {
        Debug.Log("tasfdjlksad;lkasfdjla");
        if (once)
        {
            CarSelectMenu.SetActive(true);// activates the game object storing the menu
            Time.timeScale = 0f; // changes the time in the game (used for slow motion effects)
            once = false;
        }
    }
    void Resume()
    {
        if (!once)
        {
            Debug.Log("thing");
            CarSelectMenu.SetActive(false);// deactiveates the game object storing the menu
            Time.timeScale = 1f; // changes the time in the game to 1 (1 second real life = 1 second in game)
            once = true;
        }
    }
}
