
using UnityEngine.InputSystem;

public class PushButtonMB : InputDeviceMB
{
	PushButton pushButton = new PushButton();
	public override InputDevice inputDevice => pushButton;

	void Start()
	{
		//inputDevice = new PushButton();
	}

	void Update()
    {
		if (Keyboard.current.eKey.isPressed)
			//inputDevice.Trigger();
			inputDevice.Trigger();
		if (Keyboard.current.fKey.isPressed)
			//inputDevice.Untrigger();
			inputDevice.Untrigger();
	}
}
