
using UnityEngine;

public class TriggerZoneInput : InputDevice
{
	// Box shape

	public Transform CenterTransform { get; set; }
	public Vector3 Size { get; set; }

	public void Init(Transform centerTf, Vector3 size)
	{
		CenterTransform = centerTf;
		Size = size;
	}
}