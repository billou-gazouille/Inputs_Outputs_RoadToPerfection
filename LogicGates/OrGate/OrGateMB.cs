using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class OrGateMB : InputDeviceMB
{
	OrGate orGate = new OrGate();

	[SerializeField] List<InputDeviceMB> sourceInputDeviceMBs;

	public override InputDevice inputDevice => orGate.input;

	/*
	void Awake()
	{
		List<InputDevice> inputs = inputDeviceMBs.Select(inputMB => inputMB.inputDevice).ToList();
		orGate.SetSourceInputs(inputs);
		orGate.Init();
	}
	*/

	void Start()
	{
		List<InputDevice> inputs = sourceInputDeviceMBs.Select(inputMB => inputMB.inputDevice).ToList();
		orGate.SetSourceInputs(inputs);
		orGate.Init();

		foreach (InputDeviceMB inputMB in sourceInputDeviceMBs)
		{
			inputMB.inputDevice.WorldPosition = inputMB.transform.position;
		}

		foreach (InputDevice inp in orGate.SourceInputs)
		{
			OrGate.OrGateOutput orGateOutput = new OrGate.OrGateOutput();  // intermediate
			orGateOutput.WorldPosition = transform.position;
			orGate.outputs.Add(orGateOutput);
			orGateOutput.SetInputDevice(inp);
		}
	}
}
