using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snaptospline : MonoBehaviour
{
    [SerializeField] Spline3DMonoBehaviour SplineMB;
    Spline3D spline;
    [SerializeField] float t;

    void Start()
    {
        spline = SplineMB.spline;
    }

    void Update()
    {        
        if (t >= 1f && t < spline.controlPoints.Count - 2f)
            transform.position = spline.GetPointOnSpline(t);
    }
    
}
