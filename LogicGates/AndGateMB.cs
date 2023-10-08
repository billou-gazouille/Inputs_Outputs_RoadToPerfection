using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AndGateMB : InputDeviceMB
{
	AndGate andGate = new AndGate();

    [SerializeField] List<InputDeviceMB> inputDeviceMBs;

	public override InputDevice inpDev => andGate.input;

	//void Start()
	void Awake()
	{
		//List<InputDevice> inputs = inputDeviceMBs.Select(inputMB => inputMB.inputDevice).ToList();
		List<InputDevice> inputs = inputDeviceMBs.Select(inputMB => inputMB.inpDev).ToList();
		andGate.SetInputs(inputs);
		andGate.Init();
		//inputDevice = andGate.input;
	}	
}
