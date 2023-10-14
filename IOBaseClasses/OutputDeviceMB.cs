
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
			if (connectedInputDeviceMB.inputDevice != null)
			{
				//connectedInputDeviceMB.inputDevice.WorldPosition = transform.position;
				connectedInputDeviceMB.inputDevice.WorldPosition = connectedInputDeviceMB.transform.position;
				//Debug.Log(connectedInputDeviceMB.inputDevice.WorldPosition);
			}

			outputDevice.SetInputDevice(connectedInputDeviceMB.inputDevice);

			//if (inputDeviceMB.inputDevice != null)
				//inputDeviceMB.inputDevice.WorldPosition = transform.position;
		}
		/*
		else
			outputDevice.SetInputDevice(null);
		*/
		
		else
		{
			if (outputDevice.connectedInputDevice == null)
				outputDevice.SetInputDevice(null);
			// if connectedInputDevice is not null, we want to leave it as such
		}
	}
}
