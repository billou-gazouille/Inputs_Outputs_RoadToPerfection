
using System;
using UnityEngine;

public abstract class InputDeviceMB : MonoBehaviour
{
	public abstract InputDevice inputDevice { get; }

	// (not source input), can be elsewhere than is defined by transform :
	[SerializeField] Transform inputTf;
	public Transform InputTf => inputTf;

	public virtual void InitInputDevice() { }

	void Awake()
	{
		if (inputTf != null)
			inputDevice.WorldPosition = inputTf.position;
		else
			inputDevice.WorldPosition = transform.position;
		//Debug.Log($"{name}, inputDevice.WorldPosition: {inputDevice.WorldPosition}", this);

		inputDevice.IsUsable = true;

		InitInputDevice();
	}
}