using System;

public abstract class InputDevice
{
	/*
	public InputDevice()
	{
		OnCreated?.Invoke(this);
	}

	public static event Action<InputDevice> OnCreated;
	*/

	public bool IsTriggered { get; private set; } = false;
	public event Action onTriggered;
	public event Action onUntriggered;

	public void Trigger()
	{
		if (IsTriggered)
			return;
		//onTriggered?.Invoke();
		//IsTriggered = true;
		IsTriggered = true;
		onTriggered?.Invoke();
	}

	public void Untrigger()
	{
		if (!IsTriggered)
			return;
		//onUntriggered?.Invoke();
		//IsTriggered = false;
		IsTriggered = false;
		onUntriggered?.Invoke();
	}
}
