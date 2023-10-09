using System;

public abstract class InputDevice
{
	public bool IsTriggered { get; private set; } = false;
	public event Action onTriggered;
	public event Action onUntriggered;

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
