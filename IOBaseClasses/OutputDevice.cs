
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class OutputDevice
{
	public OutputDevice()
	{
		OnCreate?.Invoke(this);
		allOutputDevices.Add(this);
	}

	public bool IsUsable { get; set; } = false;
	public static event Action<OutputDevice> OnCreate;
	public static readonly List<OutputDevice> allOutputDevices = new List<OutputDevice>();

	public InputDevice connectedInputDevice { get; protected set; }

	protected virtual void Activate() { }
	protected virtual void Deactivate() { }

	public static event Action<OutputDevice> onActivated;
	public static event Action<OutputDevice> onDeactivated;

	public static event Action<OutputDevice, InputDevice> onRegisteredInput;
	public static event Action<OutputDevice, InputDevice> onDeregisteredInput;

	public Vector3? WorldPosition { get; set; } = null;

	private void PrivateActivate()
	{
		IsActive = true;
		Activate();
		onActivated?.Invoke(this);
	}
	private void PrivateDeactivate()
	{
		IsActive = false;
		Deactivate();
		onDeactivated?.Invoke(this);
	}

	public bool IsActive { get; private set; } = false;

	protected virtual void BehaviourIfNullInput() => PrivateActivate();
	protected virtual void BehaviourIfInput()
	{
		if (connectedInputDevice.IsTriggered)
			PrivateActivate();
		else
			PrivateDeactivate();
	}

	void Register (InputDevice inputDevice)
	{
		inputDevice.onTriggered += PrivateActivate;
		inputDevice.onUntriggered += PrivateDeactivate;
		onRegisteredInput?.Invoke(this, inputDevice);
	}

	void Deregister(InputDevice inputDevice)
	{
		inputDevice.onTriggered -= PrivateActivate;
		inputDevice.onUntriggered -= PrivateDeactivate;
		onDeregisteredInput?.Invoke(this, inputDevice);
	}

	public void SetInputDevice(InputDevice newInputDevice)
	{
		if (connectedInputDevice != null)
			Deregister(connectedInputDevice);   // Detach previous input device

		connectedInputDevice = newInputDevice;
		
		if (connectedInputDevice != null)
		{
			Register(connectedInputDevice);
			BehaviourIfInput();
		}
		else
			BehaviourIfNullInput();
	}
}
