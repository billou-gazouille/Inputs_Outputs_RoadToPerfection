
using System;
using UnityEngine;

public abstract class OutputDeviceMB : MonoBehaviour
{
	
	public static event Action<OutputDevice> onCreate;

	OutputDevice _outputDevice;
	public OutputDevice outputDevice
	{
		get => _outputDevice;
		protected set
		{
			_outputDevice = value;
			onCreate?.Invoke(_outputDevice);
		}
	}
	

	//public OutputDevice outputDevice {  get; protected set; }

	[SerializeField] protected InputDeviceMB inputDeviceMB;   

	
	void Awake()
	{
		if (inputDeviceMB == null)
			return;

		InputDeviceMB.onCreate += (InputDevice inputDevice) =>
		{
			if (outputDevice == null)
				return;
			InputDevice input = inputDeviceMB.inputDevice;
			if (input == inputDevice)
			{
				outputDevice.SetInputDevice(inputDevice);
			}
		};

		onCreate += (OutputDevice output) =>
		{
			InputDevice input = inputDeviceMB.inputDevice;
			//if (input == null)
				//return;
			if (output == outputDevice)
			{
				Debug.Log(input);
				outputDevice.SetInputDevice(input);
			}
		};
	}
	

	/*
	void Awake()
	{
		if (inputDeviceMB == null)
			return;
		InputDevice input = inputDeviceMB.inputDevice;
		outputDevice.SetInputDevice(input);
		Debug.Log("here");
		Debug.Log(input);
	}
	*/
}
