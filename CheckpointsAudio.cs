using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointsAudio : MonoBehaviour
{
    void Awake()
    {
        var audioSource = GetComponent<AudioSource>();
        Checkpoint.onEntered += (Checkpoint checkpoint) => audioSource.Play();
    }
}
