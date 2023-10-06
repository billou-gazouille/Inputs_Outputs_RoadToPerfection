using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spline3D
{
    public List<Vector3> controlPoints;

    public Vector3 GetPointOnSpline(float t)
    {
        int p0, p1, p2, p3;
        p1 = (int)t;
        p2 = p1 + 1;
        p3 = p1 + 2;
        p0 = p1 - 1;

        t = t - (int)t;

        float tt = t * t;
        float ttt = tt * t;

        float q1 = -ttt + 2f * tt - t;
        float q2 =  3f * ttt - 5f * tt + 2f;
        float q3 = -3f * ttt + 4f * tt + t;
        float q4 = ttt - tt;

        float x = 0.5f * (controlPoints[p0].x * q1 + controlPoints[p1].x * q2 + controlPoints[p2].x * q3 + controlPoints[p3].x * q4);
        float y = 0.5f * (controlPoints[p0].y * q1 + controlPoints[p1].y * q2 + controlPoints[p2].y * q3 + controlPoints[p3].y * q4);
        float z = 0.5f * (controlPoints[p0].z * q1 + controlPoints[p1].z * q2 + controlPoints[p2].z * q3 + controlPoints[p3].z * q4);

        return new Vector3(x, y, z);
    }

    public Vector3 GetDerivatives(float t)
    {
        int p0, p1, p2, p3;
        p1 = (int)t;
        p2 = p1 + 1;
        p3 = p1 + 2;
        p0 = p1 - 1;

        t = t - (int)t;

        float tt = t * t;

        // differentiate with respect to t:
        float dq1dt = -3f * tt + 4f * t - 1f;
        float dq2dt = 9f * tt - 10f * t;
        float dq3dt = -9f * tt + 8f * t + 1f;
        float dq4dt = 3 * tt - 2f * t;

        float dxdt = 0.5f * (controlPoints[p0].x * dq1dt + controlPoints[p1].x * dq2dt + controlPoints[p2].x * dq3dt + controlPoints[p3].x * dq4dt);
        float dydt = 0.5f * (controlPoints[p0].y * dq1dt + controlPoints[p1].y * dq2dt + controlPoints[p2].y * dq3dt + controlPoints[p3].y * dq4dt);
        float dzdt = 0.5f * (controlPoints[p0].z * dq1dt + controlPoints[p1].z * dq2dt + controlPoints[p2].z * dq3dt + controlPoints[p3].z * dq4dt);

        return new Vector3(dxdt, dydt, dzdt);
    }

    public void SetControlPointPosition(int controlPointIndex, Vector3 newPosition)
    {
        controlPoints[controlPointIndex] = newPosition;
    }
}
