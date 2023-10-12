
using System;
using UnityEngine;

public abstract class OutputDevice
{
	public InputDevice connectedInputDevice { get; protected set; }

	protected virtual void Activate() { }
	protected virtual void Deactivate() { }

	//public event Action<InputDevice> onRegisteredInput;
	public static event Action<OutputDevice, InputDevice> onRegisteredInput;
	//public event Action<InputDevice> onDeregisteredInput;
	public static event Action<OutputDevice, InputDevice> onDeregisteredInput;

	public Vector3? WorldPosition { get; set; } = null;

	private void PrivateActivate()
	{
		Activate();
		IsActive = true;
	}
	private void PrivateDeactivate()
	{
		Deactivate();
		IsActive = false;
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
		//onRegisteredInput?.Invoke(inputDevice);
		onRegisteredInput?.Invoke(this, inputDevice);
	}

	void Deregister(InputDevice inputDevice)
	{
		inputDevice.onTriggered -= PrivateActivate;
		inputDevice.onUntriggered -= PrivateDeactivate;
		//onDeregisteredInput?.Invoke(inputDevice);
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


	/*
	//public AnimationLoop
	//protected virtual void AnimateIteration() { }
	Action _AnimateIteration;
	public virtual Action AnimationIteration { get; } = null;
	public bool HasAnimation => AnimationIteration != null;
	public void StartAnimation() => Timer.Loop(0.05f, () => AnimationIteration());
	*/
}
