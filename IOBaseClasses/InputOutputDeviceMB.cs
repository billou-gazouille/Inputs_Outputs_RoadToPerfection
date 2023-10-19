
using UnityEngine;

public abstract class InputOutputDeviceMB : InputDeviceMB
{
	public abstract InputOutputDevice inputOutputDevice { get; }
	public override InputDevice inputDevice => inputOutputDevice.input;

	/*
	public override void Init()
	{
		//Debug.Log("here");
		if (InputTf != null)
			inputDevice.WorldPosition = InputTf.position;
		else
			inputDevice.WorldPosition = transform.position;
	}
	*/
}
