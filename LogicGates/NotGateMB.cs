
using System.Collections.Generic;
using UnityEngine;

public class NotGateMB : InputDeviceMB
{
	NotGate notGate = new NotGate();

	[SerializeField] InputDeviceMB sourceInputDeviceMB;

	void Start()
	{
		InputDevice input = sourceInputDeviceMB.inputDevice;
		notGate.SetSourceInput(input);
		notGate.Init();
		inputDevice = notGate.input;
	}
}
