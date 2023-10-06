using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AndGateMB : InputDeviceMB
{
	AndGate andGate = new AndGate();

    [SerializeField] List<InputDeviceMB> inputDeviceMBs;

	void Start()
	{
		List<InputDevice> inputs = inputDeviceMBs.Select(inputMB => inputMB.inputDevice)
			.ToList();
		andGate.SetInputs(inputs);
		andGate.Init();
		inputDevice = andGate.input;
	}	
}
