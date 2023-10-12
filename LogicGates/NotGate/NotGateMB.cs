
using System.Collections.Generic;
using UnityEngine;

public class NotGateMB : InputDeviceMB
{
	NotGate notGate = new NotGate();

	[SerializeField] InputDeviceMB sourceInputDeviceMB;

	public override InputDevice inputDevice => notGate.input;

	//void Start()
	void Awake()
	{
		//InputDevice input = sourceInputDeviceMB.inputDevice;
		//InputDevice input = sourceInputDeviceMB.inputDevice;
		//notGate.SetSourceInput(input);
		//notGate.Init();
	}

	void Start()
	{
		InputDevice input = sourceInputDeviceMB.inputDevice;
		notGate.SetSourceInput(input);
		notGate.Init();
		sourceInputDeviceMB.inputDevice.WorldPosition = sourceInputDeviceMB.transform.position;
		notGate.output.WorldPosition = transform.position;
		notGate.output.SetInputDevice(notGate.SourceInput);
	}
}