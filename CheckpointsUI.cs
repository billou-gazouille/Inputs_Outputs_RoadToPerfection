using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckpointsUI : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    void Awake()
    {
        Checkpoint.onEntered += ShowEnteredTime;
    }

    void Decompose(float time, out int seconds, out int hundredths)
    {
        seconds = (int)time;
        hundredths = (int)(100 * (time - seconds));
    }
    
    void ShowEnteredTime(Checkpoint checkpoint)
    {
        Decompose(checkpoint.interCheckpointTime, out int secondsInter, out int hundredthsInter);       
        Decompose(Checkpoint.totalTime, out int secondsTotal, out int hundredthsTotal);       
        text.text += $"{secondsInter}.{hundredthsInter}s        {secondsTotal}.{hundredthsTotal}s\n";
    }
}
