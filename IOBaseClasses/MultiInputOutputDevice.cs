using System.Collections;
using System.Collections.Generic;

public abstract class MultiInputOutputDevice : InputOutputDevice
{
	public List<InputDevice> SourceInputs { get; protected set; }   // a button for example
	public List<OutputDevice> outputs { get; } = new List<OutputDevice>();   // intermediate

	public void SetupSourceInputs(List<InputDevice> srcInputs)
	{
		SourceInputs = srcInputs;

		foreach (InputDevice srcInp in SourceInputs)
		{
			srcInp.onTriggered += OnSourceInputTriggered;
			srcInp.onUntriggered += OnSourceInputUntriggered;
		}
	}
}
