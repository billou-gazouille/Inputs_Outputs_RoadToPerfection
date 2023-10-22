
public class OrGate : MultiInputOutputDevice
{
	protected override void OnOutputActivated()
	{
		if (!input.IsTriggered)
			input.Trigger();
	}

	protected override void OnOutputDeactivated()
	{
		if (!TestOr())
			input.Untrigger();
	}

	bool TestOr()
	{
		foreach (IO_OutputDevice output in outputs)
		{
			if (output.IsActive)
				return true;
		}
		return false;
	}
}
