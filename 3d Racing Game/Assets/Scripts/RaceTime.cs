using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTime : MonoBehaviour
{
    public UIManager uim;
    public UIManager otherUim;
    private int[] GameTimer = new int[3];
    public GameObject thing;
    private float countdownTime;
    public float StartTime;
    private bool once = true;
    private bool things = true;



    void Update()
    {
        if (things){
            StartTime = -Time.unscaledDeltaTime;
            things = false;
        }
        StartTime += Time.unscaledDeltaTime; // gets the current time 

       // Debug.Log(StartTime + "st");
        //Debug.Log(Time.deltaTime);
        if (StartTime > 3f)
        {
            Resume();
            GameTimer[2] = (int)((StartTime - 3f) / 3600f); // divides the current time by 3600 to get the time in hours
            GameTimer[1] = (int)(((StartTime - 3f) - (GameTimer[2] * 3600f)) / 60f);//
            GameTimer[0] = (int)((StartTime - 3f) - (GameTimer[1] * 60f) - (GameTimer[2] * 3600f));
            otherUim.ChangeTime(GameTimer[2] + ":" + GameTimer[1] + ":" + GameTimer[0]);
        }
        else
        {
            uim.CountDown(((int)(4f - StartTime)).ToString());
            Pause();
        }
    }
    void Pause()
    {
        thing.SetActive(true);// 
        Time.timeScale = 0f; // 
    }
    void Resume()
    {
        if (once)
        {
            thing.SetActive(false);// 
            Time.timeScale = 1f; // 
            once = false;
        }
    }
}
