
using System;
using UnityEngine;

public abstract class OutputDeviceMB : MonoBehaviour
{
	
	public static event Action<OutputDevice> onCreate;


	public abstract OutputDevice outDev { get; }
	

	[SerializeField] protected InputDeviceMB inputDeviceMB;


	void Start()
	{
		if (inputDeviceMB == null)
			return;
		outDev.SetInputDevice(inputDeviceMB.inpDev);
	}
}
