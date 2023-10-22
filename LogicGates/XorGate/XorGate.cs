
using UnityEngine;

public class XorGate : TwoInputOutputDevice
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
		return outputA.IsActive ^ outputB.IsActive;		// xor
	}
}
