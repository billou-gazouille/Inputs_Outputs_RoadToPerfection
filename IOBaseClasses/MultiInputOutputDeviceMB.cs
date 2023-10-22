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

	[SerializeField] Transform outputTf;    // for now, all outputs will be located here

	Dictionary<OutputDevice, InputDevice> IOs = new Dictionary<OutputDevice, InputDevice>();

	public virtual void InitMultiIODevice() { }

	public sealed override void InitInputDevice()
	{
		foreach (InputDeviceMB srcInputMB in sourceInputDevicesMB)
		{
			if (srcInputMB == null || !srcInputMB.gameObject.activeSelf)
				continue;

			multiIODevice.OutputsPos = outputTf.position;

			var output = new InputOutputDevice.IO_OutputDevice(multiIODevice);

			if (outputTf != null)
				output.WorldPosition = outputTf.position;
			else
				output.WorldPosition = transform.position;

			multiIODevice.outputs.Add(output);
			IOs.Add(output, srcInputMB.inputDevice);
		}

		foreach (OutputDevice output in multiIODevice.outputs)
		{
			output.IsUsable = true;
		}

		InitMultiIODevice();
	}


	void Start()
	{
		List<InputDevice> srcInputs = sourceInputDevicesMB
			.Where(mb => mb != null && mb.gameObject.activeSelf)
			.Select(mb => mb.inputDevice)
			.ToList();

		foreach (OutputDevice output in multiIODevice.outputs)
		{
			InputDevice input = IOs[output];
			output.SetInputDevice(input);
		}
		multiIODevice.Initialise();
	}
}
