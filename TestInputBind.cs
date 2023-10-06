using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestInputBind : MonoBehaviour
{
    [SerializeField] OutputDeviceMB outputMB;
    [SerializeField] InputDeviceMB inputMB;

	TimerButton timerButton;

	InputDevice currentInput;


	void Update()
    {
        if (Keyboard.current.bKey.wasPressedThisFrame)	// bind
        {
			timerButton = new TimerButton();
			timerButton.Init(4f);
			outputMB.outputDevice.SetInputDevice(timerButton);
			Debug.Log("Set input to a timerButton!", this);
			currentInput = timerButton;
		}

		if (Keyboard.current.uKey.wasPressedThisFrame)	// unbind
		{
			outputMB.outputDevice.SetInputDevice(inputMB.inputDevice);
			Debug.Log($"Set input to {inputMB.name}!", this);
			currentInput = inputMB.inputDevice;
		}

		if (Keyboard.current.pKey.wasPressedThisFrame)
		{			
			timerButton.Press();
		}
	}
}
