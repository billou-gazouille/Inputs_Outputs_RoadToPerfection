using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class Spline3DRenderer : MonoBehaviour
{
    [SerializeField] Spline3DMonoBehaviour splineMB;
    //Spline3D spline;

    new LineRenderer renderer;

    int n_samplePoints = 20;    // number of rendered points between 2 neighbouring control points
    float sampleStep;
    bool initialised = false;

    void Start()
    {      
        if (!initialised)
            Init();
        //renderer.enabled = false;
    }

    void Init()
    {
        //spline = splineMB.spline;
        renderer = GetComponent<LineRenderer>();
        sampleStep = 1f / n_samplePoints;
        initialised = true;
    }

    void Render()
    {
        //Debug.Log(spline);
        //renderer.positionCount = n_samplePoints * (spline.controlPoints.Count - 3);
        renderer.positionCount = n_samplePoints * (splineMB.spline.controlPoints.Count - 3);

        var pointsToRender = new List<Vector3>();
    
        //for (float t = 1f; t < spline.controlPoints.Count - 2f; t += sampleStep)
        for (float t = 1f; t < splineMB.spline.controlPoints.Count - 2f; t += sampleStep)
        {
            //var samplePoint = spline.GetPointOnSpline(t);
            var samplePoint = splineMB.spline.GetPointOnSpline(t);
            pointsToRender.Add(samplePoint);
        }

        renderer.SetPositions(pointsToRender.ToArray());
    }

    void Update()
    {
        Render();
    }


    
    void OnDrawGizmos()
    {
        //Debug.Log(splineMB.initialised);
        //if (!initialised && splineMB.initialised)
        if (!initialised && splineMB.spline != null)
            Init();
        //if (initialised)
        if (initialised && splineMB.spline != null)
        {
            //Debug.Log("renderer initialised");
            Render();
        }
        //else
            //Debug.Log("renderer not initialised yet");
    }
    
    /*
    void OnDrawGizmos()
    {
        Debug.Log("hello");
    }
    */
}
