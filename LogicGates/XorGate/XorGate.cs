
using UnityEngine;

public class XorGate : MultiInputOutputDevice
{
	protected override void OnSourceInputTriggered()
	{
		if (TestXor() && !input.IsTriggered)
			input.Trigger();
		else if (!TestXor() && input.IsTriggered)
			input.Untrigger();
	}

	protected override void OnSourceInputUntriggered()
	{
		if (TestXor() && !input.IsTriggered)
			input.Trigger();
		else if (!TestXor() && input.IsTriggered)
			input.Untrigger();
	}

	bool TestXor()
	{
		int n_inputsTriggered = 0;
		foreach (InputDevice inp in SourceInputs)
		{
			if (inp.IsTriggered)
				n_inputsTriggered++;
		}
		bool isOdd = n_inputsTriggered % 2 == 1;
		return isOdd;
	}
}
