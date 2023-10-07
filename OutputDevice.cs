
using System;

public abstract class OutputDevice
{
	public InputDevice connectedInputDevice { get; protected set; }

	protected virtual void Activate() { }
	protected virtual void Deactivate() { }

	protected virtual void BehaviourIfNullInput() { Activate(); }

	void Register (InputDevice inputDevice)
	{
		inputDevice.onTriggered += Activate;
		inputDevice.onUntriggered += Deactivate;
	}

	void Deregister(InputDevice inputDevice)
	{
		inputDevice.onTriggered -= Activate;
		inputDevice.onUntriggered -= Deactivate;
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
