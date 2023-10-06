using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineFollower : MonoBehaviour
{
    [SerializeField] public Spline3DMonoBehaviour splineMB;
    [SerializeField] float speed = 1f;
    public event Action onReachedEnd;
    public event Action<int> onReachedControlPoint;
    float prev_mod = 0.99f;
    float t;
    [SerializeField] MovementType movementType = MovementType.ConstantSpeed;

    public enum MovementType
    {
        ConstantSpeed,
        ConstantTimeInterval
    }

    public Spline3D spline { get; private set; }

    void Start()
    {
        spline = splineMB.spline;
        t = 1.01f;
    }


    void Update()
    {
        if (movementType == MovementType.ConstantSpeed)
        {
            var ds = speed * Time.deltaTime;    // spatial distance
            var delta_t = ds / spline.GetDerivatives(t).magnitude;
            t += delta_t;
            t = t % (spline.controlPoints.Count - 2);
            t = Mathf.Clamp(t, 1.01f, spline.controlPoints.Count - 2.01f);
        }

        else if (movementType == MovementType.ConstantTimeInterval)
        {
            var val = (Time.time * speed) % (spline.controlPoints.Count - 2);
            t = Mathf.Clamp(val, 1f, spline.controlPoints.Count - 2);
        }
        
        transform.position = spline.GetPointOnSpline(t);
        float currentMod = t % 1;
        if (currentMod < prev_mod)   // if new integerIndex
        {
            int controlPointIndex = (int)t;
            onReachedControlPoint?.Invoke(controlPointIndex);
        }
        prev_mod = currentMod;
    }
}
