using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfRace : MonoBehaviour
{
    public RaceTime raceTime;

    void OnTriggerEnter()//when another object collides with this object 
    {
        raceTime.SetLapTime();
        SceneManager.LoadScene(2);//calls the scenemanager and loads the scene with the index of 2
    }
    public void GetLapTime()
    {
        float time = raceTime.LapTime;
    }

}
