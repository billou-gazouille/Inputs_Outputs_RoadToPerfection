
using UnityEngine;

public abstract class SingleInputOutputDeviceMB : InputOutputDeviceMB
{
	public override InputOutputDevice inputOutputDevice => singleIODevice;
	public abstract SingleInputOutputDevice singleIODevice { get; }
	
	[SerializeField] InputDeviceMB sourceInputDeviceMB;

	void Start()
	{
		if (sourceInputDeviceMB == null)
			return;
		InputDevice srcInput = sourceInputDeviceMB.inputDevice;
		singleIODevice.SetupSourceInput(srcInput);
		singleIODevice.Init();
		sourceInputDeviceMB.inputDevice.WorldPosition = sourceInputDeviceMB.transform.position;
		var output = new InputOutputDevice.IO_OutputDevice();
		output.WorldPosition = transform.position;
		output.SetInputDevice(srcInput);

		//srcInput.onTriggered += inputOutputDevice
	}

	/*
	void Start()
	{
		inputOutputDevice.SourceInput.onTriggered += () =>
		{
			input.Untrigger();
		};

		SourceInput.onUntriggered += () =>
		{
			input.Trigger();
		};
	}
	*/
}
