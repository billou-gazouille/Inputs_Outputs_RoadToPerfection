using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public abstract class MultiInputOutputDeviceMB : InputOutputDeviceMB
{
	public override InputOutputDevice inputOutputDevice => multiIODevice;
	public abstract MultiInputOutputDevice multiIODevice { get; }

	[SerializeField] List<InputDeviceMB> sourceInputDevicesMB;

	void Start()
	{
		List<InputDevice> srcInputs = sourceInputDevicesMB
			.Select(mb => mb.inputDevice).ToList();
		multiIODevice.SetupSourceInputs(srcInputs);
		multiIODevice.Init();

		foreach (InputDeviceMB srcInputMB in sourceInputDevicesMB)
		{
			if (srcInputMB == null)
				continue;
			InputDevice srcInput = srcInputMB.inputDevice;
			srcInput.WorldPosition = srcInputMB.transform.position;
			var output = new InputOutputDevice.IO_OutputDevice();
			output.WorldPosition = transform.position;
			output.SetInputDevice(srcInput);
			multiIODevice.outputs.Add(output);
		}
	}
}
