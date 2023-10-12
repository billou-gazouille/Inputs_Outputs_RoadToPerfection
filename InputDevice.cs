using System;
using UnityEngine;

public abstract class InputDevice
{
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
