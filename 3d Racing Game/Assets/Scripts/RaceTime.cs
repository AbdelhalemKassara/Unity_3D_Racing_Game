using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTime : MonoBehaviour
{
    public UIManager uim;

    private float StartTime;
    private int hours;
    private int min;
    private int sec;
    public GameObject thing;
    private float countdownTime;

    // Update is called once per frame
    void Update()
    {
        countdownTime += Time.fixedDeltaTime;

       // Debug.Log(countdownTime + "CountdownTime");
        if (countdownTime > 3f)
        {
          
            Resume();
            StartTime += Time.fixedDeltaTime;
            hours = (int)(StartTime / 3600f);
            min = (int)(StartTime / 60f);
            sec = (int)(StartTime);
            Debug.Log(hours + ":" + min + ":" + sec);
            uim.ChangeTime(hours + ":" + min + ":" + sec);
        }
        else
        {
            Debug.Log("game should be paused");
            Pause();
        }
    }
    void Pause()
    {
        //thing.SetActive(true);// 
        Time.timeScale = 0f; // 
    }
    void Resume()
    {
        
        //thing.SetActive(false);// 
        Time.timeScale = 1f; // 
    }
}
