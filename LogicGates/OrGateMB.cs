using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OrGateMB : InputDeviceMB
{
	OrGate orGate = new OrGate();

	[SerializeField] List<InputDeviceMB> inputDeviceMBs;

	public override InputDevice inputDevice => orGate.input;

	//void Start()
	void Awake()
	{
		List<InputDevice> inputs = inputDeviceMBs.Select(inputMB => inputMB.inputDevice).ToList();
		orGate.SetSourceInputs(inputs);
		orGate.Init();
	}
}
