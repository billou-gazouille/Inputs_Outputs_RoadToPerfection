
using System;

public abstract class OutputDevice
{
	public InputDevice connectedInputDevice { get; protected set; }

	protected virtual void Activate() { }
	protected virtual void Deactivate() { }

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

	//protected virtual void BehaviourIfNullInput() { Activate(); }
	protected virtual void BehaviourIfNullInput() { PrivateActivate(); }

	void Register (InputDevice inputDevice)
	{
		//inputDevice.onTriggered += Activate;
		//inputDevice.onUntriggered += Deactivate;
		inputDevice.onTriggered += PrivateActivate;
		inputDevice.onUntriggered += PrivateDeactivate;
	}

	void Deregister(InputDevice inputDevice)
	{
		//inputDevice.onTriggered -= Activate;
		//inputDevice.onUntriggered -= Deactivate;
		inputDevice.onTriggered -= PrivateActivate;
		inputDevice.onUntriggered -= PrivateDeactivate;
	}

	public void SetInputDevice(InputDevice newInputDevice)
	{
		if (connectedInputDevice != null)
			Deregister(connectedInputDevice);   // Detach previous input device
		//else
			//BehaviourIfNullInput();

		connectedInputDevice = newInputDevice;
		
		if (connectedInputDevice != null)
			Register(connectedInputDevice);
		else
			BehaviourIfNullInput();
	}
}
