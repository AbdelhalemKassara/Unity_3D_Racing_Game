using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTime : MonoBehaviour
{
    public UIManager uim;
    public UIManager otherUim;
    private int[] GameTimer = new int[3];
    public GameObject thing;
    private float countDownTime;
    public float StartTime;
    private bool once = true;
    private bool things = true;
    private bool thing1 = true;


    void Update()
    {
        if (things)
        {// use 2 variables one for countdown one for lap time (deltatime,unscaleddeltatime)
            countDownTime = -Time.unscaledDeltaTime;//Time.unscaledDeltaTime
            things = false;
        }

        // Debug.Log(StartTime + "st");
        //Debug.Log(Time.deltaTime);
        if (countDownTime > 3f)
        {
            if (thing1)
            {
                StartTime += Time.deltaTime + countDownTime;
                thing1 = false;
            }
            StartTime += Time.deltaTime;

            Resume();
            GameTimer[2] = (int)((StartTime - 3f) / 3600f); // divides the current time by 3600 to get the time in hours
            GameTimer[1] = (int)(((StartTime - 3f) - (GameTimer[2] * 3600f)) / 60f);//
            GameTimer[0] = (int)((StartTime - 3f) - (GameTimer[1] * 60f) - (GameTimer[2] * 3600f));
            otherUim.ChangeTime(GameTimer[2] + ":" + GameTimer[1] + ":" + GameTimer[0]);
        }
        else
        {
            countDownTime += Time.unscaledDeltaTime; // gets the time inbetween the last frame and this frame, uscaled is the time unaffected by the timescale  
            uim.CountDown(((int)(4f - countDownTime)).ToString());
            Pause();
        }
    }
    void Pause()
    {
        thing.SetActive(true);// 
        
            Time.timeScale = 0f; // used for slow motion
        
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
