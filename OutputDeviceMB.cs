
using System;
using UnityEngine;

public abstract class OutputDeviceMB : MonoBehaviour
{
	
	public static event Action<OutputDevice> onCreated;

	OutputDevice _outputDevice;
	public OutputDevice outputDevice
	{
		get => _outputDevice;
		protected set
		{
			_outputDevice = value;
			onCreated?.Invoke(_outputDevice);
		}
	}
	

	//public OutputDevice outputDevice {  get; protected set; }

	[SerializeField] protected InputDeviceMB inputDeviceMB;   

	void Awake()
	{
		if (inputDeviceMB == null)
			return;

		InputDeviceMB.onCreated += (InputDevice inputDevice) =>
		{
			if (outputDevice == null)
				return;
			InputDevice input = inputDeviceMB.inputDevice;
			if (input == inputDevice)
			{
				outputDevice.SetInputDevice(inputDevice);
			}
		};

		onCreated += (OutputDevice output) =>
		{
			InputDevice input = inputDeviceMB.inputDevice;
			if (input == null)
				return;
			if (output == outputDevice)
			{
				outputDevice.SetInputDevice(input);
			}
		};
	}	
}
