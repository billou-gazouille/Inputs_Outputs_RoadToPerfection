
using System.Collections.Generic;
using UnityEngine;


public class Spawncats : MonoBehaviour
{
    [SerializeField] GameObject catPrefab;
    [SerializeField] SplineFollower splineFollower;
    Spline3D spline;
    List<Vector3> controlPoints;

    void Awake()
    {
		splineFollower.onReachedControlPoint += (int index) =>
        {
			var go = Instantiate(catPrefab, controlPoints[index], Quaternion.identity);
            Timer.WaitThenDo(1f, () => Destroy(go));
			//Debug.Log(transform.root.name);
		};
    }

	void Start()
	{
        spline = splineFollower.spline;
		controlPoints = spline.controlPoints;
	}
}
