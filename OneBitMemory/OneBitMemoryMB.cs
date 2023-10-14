
using UnityEngine;

public class OneBitMemoryMB : InputDeviceMB
{
	OneBitMemory oneBitMemory = new OneBitMemory();

	[SerializeField] InputDeviceMB sourceInputDeviceMB;

	public override InputDevice inputDevice => oneBitMemory.input;

	//void Start()
	void Awake()
	{
		//InputDevice input = sourceInputDeviceMB.inputDevice;
		//InputDevice input = sourceInputDeviceMB.inputDevice;
		//notGate.SetSourceInput(input);
		//notGate.Init();
	}

	void Start()
	{
		InputDevice input = sourceInputDeviceMB.inputDevice;
		oneBitMemory.SetSourceInput(input);
		oneBitMemory.Init();
		sourceInputDeviceMB.inputDevice.WorldPosition = sourceInputDeviceMB.transform.position;
		oneBitMemory.output.WorldPosition = transform.position;
		oneBitMemory.output.SetInputDevice(oneBitMemory.SourceInput);
	}
}
