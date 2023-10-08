using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimersTicker : MonoBehaviour, ITimersTicker
{
    List<Timer> timers = new List<Timer>();

    private void Awake()
    {
        //Debug.Log("awake timers ticker");
        Timer.SetTimersTicker(this);
        Timer.onCreate += (timer) => AddTimer(timer);
    }

    public void AddTimer(Timer timer)
    {
        //Debug.Log("adding a timer", this);
        timers.Add(timer);
    }

    public void TickTimers()
    {
        //Debug.Log(timers.Count);

        // a foreach loop causes an issue because the tick sometimes causes a new timer to be created, 
        // hence changing the timer's list still within the foreach body, 
        // but using a for loop instead works as intended:

        for (int i = 0; i < timers.Count; i++)
        {
            timers[i].Tick(Time.deltaTime);
        }
    }

    void Update()
    {
        TickTimers();
    }
}
