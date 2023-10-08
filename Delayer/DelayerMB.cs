
using UnityEngine;

public class DelayerMB : InputDeviceMB
{
	Delayer delayer = new Delayer();

	[SerializeField] InputDeviceMB sourceInputDeviceMB;
	[SerializeField] float delay;

	public override InputDevice inpDev => delayer.input;

	void Start()
	{
		if (sourceInputDeviceMB == null)
			return;
		//InputDevice input = sourceInputDeviceMB.inputDevice;
		InputDevice input = sourceInputDeviceMB.inpDev;
		//Debug.Log($"sourceInputDeviceMB: {sourceInputDeviceMB.name}", this);
		//Debug.Log($"sourceInputDeviceMB.inputDevice null?: {input == null}", this);
		delayer.SetSourceInput(input);
		delayer.Init(delay);
		//inputDevice = delayer.input;
	}
}
