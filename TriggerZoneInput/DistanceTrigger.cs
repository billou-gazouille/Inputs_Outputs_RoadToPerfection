using System;
using UnityEngine;

public class DistanceTrigger : MonoBehaviour
{
	public float Range { get; set; }
	public Transform OtherTf { get; set; }

	public bool IsInRange { get; private set; } = false;

	public event Action onEnteredSphere;
	public event Action onLeftSphere;

	void Update()
	{
		float distance = Vector3.Distance(transform.position, OtherTf.position);
		
		if (distance < Range && !IsInRange)
		{
			IsInRange = true;
			onEnteredSphere.Invoke();
		}

		else if (distance >= Range && IsInRange)
		{
			IsInRange = false;
			onLeftSphere.Invoke();
		}
	}
}
