
using UnityEngine;

public abstract class SingleInputOutputDeviceMB : InputOutputDeviceMB
{
	public override InputOutputDevice inputOutputDevice => singleIODevice;
	public abstract SingleInputOutputDevice singleIODevice { get; }
	
	[SerializeField] InputDeviceMB sourceInputDeviceMB;

	[SerializeField] Transform outputTf;

	public virtual void InitSingleIODevice() { }

	public sealed override void InitInputDevice()
	{
		singleIODevice.output = new InputOutputDevice.IO_OutputDevice(singleIODevice);
		if (outputTf != null)
			singleIODevice.output.WorldPosition = outputTf.position;
		else
			singleIODevice.output.WorldPosition = transform.position;

		singleIODevice.output.IsUsable = true;

		InitSingleIODevice();
	}


	void Start()
	{
		if (sourceInputDeviceMB == null || !sourceInputDeviceMB.gameObject.activeSelf)
			return;
		InputDevice srcInput = sourceInputDeviceMB.inputDevice;
		singleIODevice.output.SetInputDevice(srcInput);
		singleIODevice.Initialise();
	}
}
