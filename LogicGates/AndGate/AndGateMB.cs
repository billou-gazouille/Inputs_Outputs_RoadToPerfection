using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AndGateMB : InputDeviceMB
{
	AndGate andGate = new AndGate();

    [SerializeField] List<InputDeviceMB> sourceInputDeviceMBs;

	public override InputDevice inputDevice => andGate.input;

	/*
	void Awake()
	{
		//List<InputDevice> inputs = inputDeviceMBs.Select(inputMB => inputMB.inputDevice).ToList();
		List<InputDevice> inputs = inputDeviceMBs.Select(inputMB => inputMB.inputDevice).ToList();
		andGate.SetInputs(inputs);
		andGate.Init();
		//inputDevice = andGate.input;

		foreach (InputDevice inp in andGate.SourceInputs)
		{
			AndGateOutput andGateOutput = new AndGateOutput();  // intermediate
			andGateOutput.WorldPosition = transform.position;
			andGate.outputs.Add(andGateOutput);
			andGateOutput.SetInputDevice(inp);
			//andGateOutput.SetInputDevice(new TestInput());
		}
	}
	*/
	
	void Start()
	{
		List<InputDevice> inputs = sourceInputDeviceMBs.Select(inputMB => inputMB.inputDevice).ToList();
		andGate.SetSourceInputs(inputs);
		andGate.Init();

		foreach (InputDeviceMB inputMB in sourceInputDeviceMBs)
		{
			inputMB.inputDevice.WorldPosition = inputMB.transform.position;
		}

		foreach (InputDevice inp in andGate.SourceInputs)
		{
			AndGate.AndGateOutput andGateOutput = new AndGate.AndGateOutput();  // intermediate
			andGateOutput.WorldPosition = transform.position;
			andGate.outputs.Add(andGateOutput);
			andGateOutput.SetInputDevice(inp);
		}
	}
}
