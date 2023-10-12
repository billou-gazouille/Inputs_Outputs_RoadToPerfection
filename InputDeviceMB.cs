
using System;
using UnityEngine;

public abstract class InputDeviceMB : MonoBehaviour
{
	public abstract InputDevice inputDevice { get; }

	void Start()
	{
		 //if (inputDevice.WorldPosition == null)
			//inputDevice.WorldPosition = transform.position;
	}
}