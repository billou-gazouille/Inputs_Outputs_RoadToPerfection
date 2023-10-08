
using UnityEngine;

public class Pillar : OutputDevice
{
	public float Angle { get; private set; } = 0f;
	public float Speed { get; private set; } = 20f;

	public void UpdateAngle()
	{
		var dir = IsActive ? 1f : -1f;
		Angle = Mathf.Clamp(Angle + Time.deltaTime * Speed * dir, 0f, 90f);
	}
}
