
using System;
using UnityEngine;

public class Timer
{

    public Timer(float duration)
    {
        if (timersTicker == null)
            Debug.LogError("There is currently no existing timers-ticker object.");
        onCreate?.Invoke(this);
        Set(duration);
    }

    public static ITimersTicker timersTicker { get; private set; }

    public float RemainingTime { get; private set; }
    public float duration;
    //public event Action onFinished;
    public static event Action<Timer> onCreate;
    public Action onFinished;
    public bool IsRunning { get; private set; } = false;

    public static void SetTimersTicker(ITimersTicker ticker)
    {
        timersTicker = ticker;
    }

    public void Tick(float deltaTime)
    {
        if (!IsRunning)
            return;

        RemainingTime -= deltaTime;
        if (RemainingTime <= 0f)
        {
            IsRunning = false;
            onFinished?.Invoke();
        }
    }

    public void Set(float duration)
    {
        this.duration = duration;
        RemainingTime = duration;
        IsRunning = false;
    }

    public void Start()
    {
        IsRunning = true;
    }

    public void Pause()
    {
        IsRunning = false;
    }

    public void Reset()
    {
        RemainingTime = duration;
        IsRunning = false;
    }

    public static void WaitThenDo(float delay, Action action)
    {
        Timer timer = new Timer(delay);
        timer.onFinished = action;
        timer.Start();
    }

    public static void Loop(float delay, Action action)
    {
        WaitThenDo(delay, () =>
        {
            action.Invoke();
            Loop(delay, action);
        });
    }
}