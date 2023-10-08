
using UnityEngine;
using UnityEngine.InputSystem;

public class TestInputMB : InputDeviceMB
{
    TestInput testInput = new TestInput();

	public override InputDevice inpDev => testInput;

	void Update()
    {
        if (Keyboard.current.tKey.wasPressedThisFrame)
		{
			Debug.Log("Pressed t");
            testInput.Trigger();
		}

		else if (Keyboard.current.uKey.wasPressedThisFrame)
		{
			Debug.Log("Pressed u");
			testInput.Untrigger();
		}
	}
}
