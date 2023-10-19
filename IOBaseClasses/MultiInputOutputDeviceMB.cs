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

	// map source inputs to internal outputs :
	//Dictionary<InputDevice, OutputDevice> IOs = new Dictionary<InputDevice, OutputDevice>();

	public virtual void InitMultiIODevice() { }

	public sealed override void InitInputDevice()
	{
		foreach (InputDeviceMB srcInputMB in sourceInputDevicesMB)
		{
			if (srcInputMB == null)
				continue;
			var output = new InputOutputDevice.IO_OutputDevice();

			if (outputTf != null)
				output.WorldPosition = outputTf.position;
			else
				output.WorldPosition = transform.position;

			multiIODevice.outputs.Add(output);
			//IOs.Add(srcInputMB.inputDevice, output);
			multiIODevice.IOs.Add(srcInputMB.inputDevice, output);
		}

		InitMultiIODevice();
	}


	void Start()
	{
		List<InputDevice> srcInputs = sourceInputDevicesMB
			.Where(mb => mb != null)
			.Select(mb => mb.inputDevice)
			.ToList();

		multiIODevice.SetSourceInputDevices(srcInputs);
		multiIODevice.Initialise();
	}
}
