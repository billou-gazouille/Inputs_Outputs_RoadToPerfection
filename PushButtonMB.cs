
using UnityEngine.InputSystem;

public class PushButtonMB : InputDeviceMB
{
	void Start()
	{
		inputDevice = new PushButton();
	}

	void Update()
    {
		if (Keyboard.current.eKey.isPressed)
			inputDevice.Trigger();
		if (Keyboard.current.fKey.isPressed)
			inputDevice.Untrigger();
	}
}
