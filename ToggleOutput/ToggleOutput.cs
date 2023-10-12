
using UnityEngine;

public class ToggleOutput : OutputDevice
{
	public ToggleOutput(InputDevice inp, OutputDevice out1, OutputDevice out2)
	{
		input = inp;
		output1 = out1;
		output2 = out2;
		SetOutput(true);

		// not reliable to call SetOutput here, because this happens in the awake of ToggleOutputMB,
		//		which is before the OutputDevice's Start sets the input device.
	}

	InputDevice input;
	OutputDevice output1;
	OutputDevice output2;
	public OutputDevice CurrentOutput { get; private set; }

	protected override void Activate() => ToggleOut();

	void ToggleOut()
	{
		if (CurrentOutput == output1)
			SetOutput(false);
		else
			SetOutput(true);
		//Debug.Log(output1.connectedInputDevice);
		//Debug.Log(output2.connectedInputDevice);
	}

	void SetOutput(bool isOutput1)
	{
		if (isOutput1)
		{
			output1.SetInputDevice(input);
			output2.SetInputDevice(null);
			CurrentOutput = output1;
		}
		else
		{
			output1.SetInputDevice(null);
			output2.SetInputDevice(input);
			CurrentOutput = output2;
		}
	}
}
