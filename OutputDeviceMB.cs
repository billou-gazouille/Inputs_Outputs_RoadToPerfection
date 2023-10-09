
using System;
using UnityEngine;

public abstract class OutputDeviceMB : MonoBehaviour
{
	public abstract OutputDevice outputDevice { get; }

	[SerializeField] protected InputDeviceMB inputDeviceMB;

	void Start()
	{
		if (inputDeviceMB != null)
			outputDevice.SetInputDevice(inputDeviceMB.inputDevice);
		else
			outputDevice.SetInputDevice(null);
	}
}
