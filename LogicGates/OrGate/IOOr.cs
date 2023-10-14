
public class IOOr : MultiInputOutputDevice
{
	protected override void OnSourceInputTriggered()
	{
		if (!input.IsTriggered)
			input.Trigger();
	}

	protected override void OnSourceInputUntriggered()
	{
		if (!TestOr())
			input.Untrigger();
	}

	bool TestOr()
	{
		foreach (var inp in SourceInputs)
		{
			if (inp.IsTriggered)
				return true;
		}
		return false;
	}
}
