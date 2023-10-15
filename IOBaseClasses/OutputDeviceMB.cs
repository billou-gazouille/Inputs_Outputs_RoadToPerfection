
using System;
using UnityEngine;

public abstract class OutputDeviceMB : MonoBehaviour
{
	public abstract OutputDevice outputDevice { get; }

	[SerializeField] protected InputDeviceMB connectedInputDeviceMB;

	void Start()
	{
		outputDevice.WorldPosition = transform.position;

		if (connectedInputDeviceMB != null)
		{
			/*
			if (connectedInputDeviceMB.inputDevice != null)
				connectedInputDeviceMB.inputDevice.WorldPosition = connectedInputDeviceMB.transform.position;

			outputDevice.SetInputDevice(connectedInputDeviceMB.inputDevice);
			*/
			SetInputDeviceMB(connectedInputDeviceMB);
		}
		
		else
		{
			if (outputDevice.connectedInputDevice == null)
				outputDevice.SetInputDevice(null);
			// if connectedInputDevice is not null, we want to leave it as such
		}
	}

	public void SetInputDeviceMB(InputDeviceMB inputDeviceMB)
	{
		if (inputDeviceMB.inputDevice != null)
			inputDeviceMB.inputDevice.WorldPosition = inputDeviceMB.transform.position;

		outputDevice.SetInputDevice(inputDeviceMB.inputDevice);
	}
}
