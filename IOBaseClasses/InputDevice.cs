using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputDevice
{
	public InputDevice()
	{
		OnCreate?.Invoke(this);
		allInputDevices.Add(this);
		//Debug.Log(this);
	}

	public bool IsUsable { get; set; } = false;
	public static event Action<InputDevice> OnCreate;
	public static readonly List<InputDevice> allInputDevices = new List<InputDevice>();

	public bool IsTriggered { get; private set; } = false;
	public event Action onTriggered;
	public event Action onUntriggered;


	public Vector3? WorldPosition { get; set; } = null;

	public void Trigger()
	{
		if (IsTriggered)
			return;
		IsTriggered = true;
		onTriggered?.Invoke();
	}

	public void Untrigger()
	{
		if (!IsTriggered)
			return;
		IsTriggered = false;
		onUntriggered?.Invoke();
	}
}
