
using UnityEngine;

public abstract class InputOutputDeviceMB : InputDeviceMB
{
	public abstract InputOutputDevice inputOutputDevice { get; }
	public override InputDevice inputDevice => inputOutputDevice.input;
}
