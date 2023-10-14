
using System;
using UnityEngine;

public abstract class OutputDevice
{
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
		Activate();
		IsActive = true;
		onActivated?.Invoke(this);
	}
	private void PrivateDeactivate()
	{
		Deactivate();
		IsActive = false;
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
