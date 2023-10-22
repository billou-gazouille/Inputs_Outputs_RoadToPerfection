using UnityEngine;

public class AndGate : MultiInputOutputDevice
{
	protected override void OnOutputActivated()
	{
		Debug.Log("AND: OnOutputActivated");
		Debug.Log(outputs.Count);
		Debug.Log(outputs[0].IsActive);
		if (TestAnd())
			input.Trigger();
	}

	protected override void OnOutputDeactivated()
	{
		if (input.IsTriggered)
			input.Untrigger();
	}

	bool TestAnd()
	{
		foreach (IO_OutputDevice output in outputs)
		{
			if (!output.IsActive)
				return false;
		}
		return true;
	}
}
