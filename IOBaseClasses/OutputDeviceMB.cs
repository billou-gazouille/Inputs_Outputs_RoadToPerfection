
using System;
using UnityEngine;

public abstract class OutputDeviceMB : MonoBehaviour
{
	public abstract OutputDevice outputDevice { get; }

	[SerializeField] protected InputDeviceMB connectedInputDeviceMB;

	public virtual void InitOutputDevice() { }

	// Can be elsewhere than is defined by transform :
	[SerializeField] Transform outputTf;

	void Awake()
	{		
		if (outputTf != null)
			outputDevice.WorldPosition = outputTf.position;
		else
			outputDevice.WorldPosition = transform.position;
		
		InitOutputDevice();
	}

	void Start()
	{
		if (connectedInputDeviceMB != null)
			SetInputDeviceMB(connectedInputDeviceMB);
		
		else
		{
			if (outputDevice.connectedInputDevice == null)
				outputDevice.SetInputDevice(null);
			// if connectedInputDevice is not null, we want to leave it as such
		}
	}

	public void SetInputDeviceMB(InputDeviceMB inputDeviceMB)
	{
		outputDevice.SetInputDevice(inputDeviceMB.inputDevice);
	}
}
