
public class OrGate : TwoInputOutputDevice
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
		return outputA.IsActive || outputB.IsActive;
	}
}
