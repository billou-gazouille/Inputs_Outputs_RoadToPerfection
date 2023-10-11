using System;
using UnityEngine;

public class DistanceTriggerZone : ITriggerZone
{
	public DistanceTriggerZone(GameObject go, Transform otherTf, float range)
	{
		distanceTrigger = go.AddComponent<DistanceTrigger>();
		distanceTrigger.Range = range;
		distanceTrigger.OtherTf = otherTf;
		distanceTrigger.onEnteredSphere += onEntered;
		distanceTrigger.onLeftSphere += onLeft;
	}

	DistanceTrigger distanceTrigger;

	public event Action onEntered;
	public event Action onLeft;
}
