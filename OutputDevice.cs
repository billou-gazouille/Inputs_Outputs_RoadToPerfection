
using System;

public abstract class OutputDevice
{
	/*
	public OutputDevice()
	{
		OnCreated?.Invoke(this);
	}

	public static event Action<OutputDevice> OnCreated;
	*/

	protected InputDevice inputDevice;

	protected virtual void Activate() { }
	protected virtual void Deactivate() { }

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
		if (inputDevice != null)
			Deregister(inputDevice);   // Detach previous input device

		inputDevice = newInputDevice;
		Register(inputDevice);
	}
}
