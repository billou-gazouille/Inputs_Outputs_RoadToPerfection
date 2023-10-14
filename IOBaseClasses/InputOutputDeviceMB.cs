using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputOutputDeviceMB : InputDeviceMB
{
	[SerializeField] InputDeviceMB sourceInputDeviceMB;

	public abstract InputOutputDevice inputOutputDevice { get; }
	public InputDevice input => inputOutputDevice.input;
	public OutputDevice output => inputOutputDevice.output;

	public override InputDevice inputDevice => input;


	//void Awake()
	void Start()
	{
		/*
		InputDevice input = sourceInputDeviceMB.inputDevice;
		notGate.SetSourceInput(input);
		notGate.Init();
		sourceInputDeviceMB.inputDevice.WorldPosition = sourceInputDeviceMB.transform.position;
		notGate.output.WorldPosition = transform.position;
		notGate.output.SetInputDevice(notGate.SourceInput);
		*/

		InputDevice input = sourceInputDeviceMB.inputDevice;
		inputOutputDevice.SetupSourceInput(input);
		inputOutputDevice.Init();
		sourceInputDeviceMB.inputDevice.WorldPosition = sourceInputDeviceMB.transform.position;
		inputOutputDevice.output.WorldPosition = transform.position;
		output.SetInputDevice(sourceInputDeviceMB.inputDevice);
	}

	/*
	void Start()
	{
		sourceInputDeviceMB.inputDevice.WorldPosition = sourceInputDeviceMB.transform.position;
		inputOutputDevice.output.WorldPosition = transform.position;
	}
	*/
}
