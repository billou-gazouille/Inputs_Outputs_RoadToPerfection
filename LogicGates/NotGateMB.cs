
using System.Collections.Generic;
using UnityEngine;

public class NotGateMB : InputDeviceMB
{
	NotGate notGate = new NotGate();

	[SerializeField] InputDeviceMB sourceInputDeviceMB;

	public override InputDevice inpDev => notGate.input;

	//void Start()
	void Awake()
	{
		//InputDevice input = sourceInputDeviceMB.inputDevice;
		InputDevice input = sourceInputDeviceMB.inpDev;
		notGate.SetSourceInput(input);
		notGate.Init();
	}
}
