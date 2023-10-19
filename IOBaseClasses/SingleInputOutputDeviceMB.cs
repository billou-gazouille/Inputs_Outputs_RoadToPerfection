
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
		if (outputTf != null)
			singleIODevice.output.WorldPosition = outputTf.position;
		else
			singleIODevice.output.WorldPosition = transform.position;

		InitSingleIODevice();
	}


	void Start()
	{
		if (sourceInputDeviceMB == null)
			return;
		InputDevice srcInput = sourceInputDeviceMB.inputDevice;
		singleIODevice.SetSourceInputDevice(srcInput);
		singleIODevice.Initialise();
	}
}
