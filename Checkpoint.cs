using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Checkpoint : MonoBehaviour
{
    [SerializeField] Checkpoint previousCheckpoint;
    [HideInInspector] public Checkpoint nextCheckpoint;
    [SerializeField] Collider player;
    public float timeWhenEntered { get; private set; }
    public float interCheckpointTime { get; private set; } = 0f;
    public static float totalTime { get; private set; } = 0f;
    public bool alreadyEntered { get; private set; } = false;
    public static event Action<Checkpoint> onEntered;

    private void Start()
    {
        if (previousCheckpoint != null)
            previousCheckpoint.nextCheckpoint = this;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other != player)
            return;
        if (alreadyEntered)
            return;
        Vector3 playerDirection = (transform.position - other.transform.position).normalized;
        bool wrongDirection = Vector3.Dot(playerDirection, transform.forward) < 0f;
        if (wrongDirection)
        {
            Debug.Log("Wrong direction !");
            return;
        }
        timeWhenEntered = Time.time;
        //Debug.Log("Good job!");
        if (previousCheckpoint != null)
        {
            interCheckpointTime = timeWhenEntered - previousCheckpoint.timeWhenEntered;
            totalTime += interCheckpointTime;
            //Debug.Log(interCheckpointTime);
        }
        alreadyEntered = true;
        onEntered?.Invoke(this);
    }
}
