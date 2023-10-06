
using System;
using UnityEngine;

public abstract class InputDeviceMB : MonoBehaviour
{
	public static event Action<InputDevice> onCreated;

	protected InputDevice _inputDevice;
	public virtual InputDevice inputDevice
	{ 
		get => _inputDevice; 
		protected set
		{
			_inputDevice = value;
			onCreated?.Invoke(_inputDevice);
		} 
	}

	//public static void Test(InputDevice input) => onCreated?.Invoke(input);
}