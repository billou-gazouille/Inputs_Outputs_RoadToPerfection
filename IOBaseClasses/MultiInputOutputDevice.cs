using System.Collections;
using System.Collections.Generic;

public abstract class MultiInputOutputDevice : InputOutputDevice
{
	public List<InputDevice> SourceInputs { get; protected set; }   // a button for example
	public List<OutputDevice> outputs { get; } = new List<OutputDevice>();   // intermediate

	// map source inputs to internal outputs :
	public Dictionary<InputDevice, OutputDevice> IOs = new Dictionary<InputDevice, OutputDevice>();

	public void SetSourceInputDevices(List<InputDevice> srcInputs)
	{
		SourceInputs = srcInputs;

		foreach (InputDevice srcInp in SourceInputs)
		{
			srcInp.onTriggered += OnSourceInputTriggered;
			srcInp.onUntriggered += OnSourceInputUntriggered;
			OutputDevice output = IOs[srcInp];
			output.SetInputDevice(srcInp);
		}
	}
}
