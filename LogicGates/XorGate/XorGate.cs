
using UnityEngine;

public class XorGate : MultiInputOutputDevice
{
	protected override void OnOutputActivated()
	{
		if (TestXor() && !input.IsTriggered)
			input.Trigger();
		else if (!TestXor() && input.IsTriggered)
			input.Untrigger();
	}

	protected override void OnOutputDeactivated()
	{
		if (TestXor() && !input.IsTriggered)
			input.Trigger();
		else if (!TestXor() && input.IsTriggered)
			input.Untrigger();
	}

	bool TestXor()
	{
		int n_inputsTriggered = 0;
		foreach (IO_OutputDevice output in outputs)
		{
			if (output.IsActive)
				n_inputsTriggered++;
		}
		bool isOdd = n_inputsTriggered % 2 == 1;
		return isOdd;
	}
}
