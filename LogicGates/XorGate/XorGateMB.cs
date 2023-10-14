using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class XorGateMB : InputDeviceMB
{
	XorGate xorGate = new XorGate();
	[SerializeField] List<InputDeviceMB> sourceInputDeviceMBs;
	public override InputDevice inputDevice => xorGate.input;

	void Start()
	{
		List<InputDevice> inputs = sourceInputDeviceMBs.Select(inputMB => inputMB.inputDevice).ToList();
		xorGate.SetSourceInputs(inputs);
		xorGate.Init();

		foreach (InputDeviceMB inputMB in sourceInputDeviceMBs)
		{
			inputMB.inputDevice.WorldPosition = inputMB.transform.position;
		}

		foreach (InputDevice inp in xorGate.SourceInputs)
		{
			XorGate.XorGateOutput xorGateOutput = new XorGate.XorGateOutput();  // intermediate
			xorGateOutput.WorldPosition = transform.position;
			xorGate.outputs.Add(xorGateOutput);
			xorGateOutput.SetInputDevice(inp);
		}
	}
}
