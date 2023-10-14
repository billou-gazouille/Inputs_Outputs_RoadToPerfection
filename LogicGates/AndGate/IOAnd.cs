using System.Collections;
using System.Collections.Generic;

public class IOAnd : MultiInputOutputDevice
{
	protected override void OnSourceInputTriggered()
	{
		if (TestAnd())
			input.Trigger();
	}

	protected override void OnSourceInputUntriggered()
	{
		if (input.IsTriggered)
			input.Untrigger();
	}

	bool TestAnd()
	{
		foreach (var inp in SourceInputs)
		{
			if (!inp.IsTriggered)
				return false;
		}
		return true;
	}
}
