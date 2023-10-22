using System;
using UnityEngine;

public abstract class TwoInputOutputDeviceMB : InputOutputDeviceMB
{
	public override InputOutputDevice inputOutputDevice => twoIODevice;
	public abstract TwoInputOutputDevice twoIODevice { get; }

	[SerializeField] InputDeviceMB sourceInputDevicesMB_A;
	[SerializeField] InputDeviceMB sourceInputDevicesMB_B;

	[SerializeField] Transform outputTfA;
	[SerializeField] Transform outputTfB;

	public virtual void InitTwoIODevice() { }

	void SetupOutput(InputOutputDevice.IO_OutputDevice output, Transform outputTf)
	{
		if (outputTf != null)
			output.WorldPosition = outputTf.position;
		else
			output.WorldPosition = transform.position;

		output.IsUsable = true;

		InitTwoIODevice();
	}

	void Connect(InputDeviceMB srcInputMB, OutputDevice output)
	{
		if (srcInputMB == null || !srcInputMB.gameObject.activeSelf)
			return;

		output.SetInputDevice(srcInputMB.inputDevice);
	}

	public sealed override void InitInputDevice()
	{
		twoIODevice.outputA.Setup(twoIODevice);
		twoIODevice.outputB.Setup(twoIODevice);

		SetupOutput(twoIODevice.outputA, outputTfA);
		SetupOutput(twoIODevice.outputB, outputTfB);
	}


	void Start()
	{
		Connect(sourceInputDevicesMB_A, twoIODevice.outputA);
		Connect(sourceInputDevicesMB_B, twoIODevice.outputB);

		twoIODevice.Initialise();
	}
}
