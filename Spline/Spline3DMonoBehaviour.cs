using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class Spline3DMonoBehaviour : MonoBehaviour
{
    public Spline3D spline;
    //List<Transform> controlTransforms;

    [SerializeField] bool showControlPoints = true;
    bool controlPointsShown = true;
    List<Renderer> controlPointRenderers;
    public bool initialised { get; private set; } = false;
    [SerializeField] bool loop = false;

    void Awake()
    {
        if (!initialised)
            InitSpline();

        UpdateControlPoints();
        //showControlPoints = false;
        //UpdateControlPointsVisibility();
    }

    void Update()
    {
        UpdateControlPoints();
        UpdateControlPointsVisibility();
    }

    void UpdateControlPoints()
    {
        spline.controlPoints = new List<Vector3>();

        for (int i = 0; i < transform.childCount; i++)
        {
            spline.controlPoints.Add(transform.GetChild(i).position);
        }

        if (loop)
        {
            if (spline.controlPoints.Count >= 5)
            {
                spline.controlPoints[0] = spline.controlPoints[spline.controlPoints.Count - 3];
                transform.GetChild(0).position = spline.controlPoints[0];
                spline.controlPoints[1] = spline.controlPoints[spline.controlPoints.Count - 2];
                transform.GetChild(1).position = spline.controlPoints[1];
                spline.controlPoints[2] = spline.controlPoints[spline.controlPoints.Count - 1];
                transform.GetChild(2).position = spline.controlPoints[2];
            }
            else
                Debug.LogWarning("Cannot loops with fewer than 5 control points !");
        }
    }

    void InitSpline()
    {
        spline = new Spline3D();
        UpdateControlPoints();
        UpdateControlPointsVisibility();
        initialised = true;
    }

    void UpdateControlPointsVisibility()
    {
        controlPointRenderers = new List<Renderer>();
        for (int i = 0; i < transform.childCount; i++)
        {
            controlPointRenderers.Add(transform.GetChild(i).GetComponent<Renderer>());
        }

        if (showControlPoints && !controlPointsShown)
        {
            foreach (var renderer in controlPointRenderers)
            {
                renderer.enabled = true;
            }
            controlPointsShown = true;
        }

        if (!showControlPoints && controlPointsShown)
        {
            foreach (var renderer in controlPointRenderers)
            {
                renderer.enabled = false;
            }
            controlPointsShown = false;
        }
    }

    public void SetControlPointPosition(int controlPointIndex, Vector3 newPosition)
    {
        spline.SetControlPointPosition(controlPointIndex, newPosition);
        transform.GetChild(controlPointIndex).position = newPosition;
    }

    void OnDrawGizmos()
    {
        //if (!initialised)
        if (spline == null)
            InitSpline();
        UpdateControlPoints();
        UpdateControlPointsVisibility();
    }
}
