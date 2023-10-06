
using System.Collections.Generic;
using UnityEngine;

public class OrGate
{
	class OrGateInput : InputDevice { }

	public List<InputDevice> SourceInputs { get; private set; }

	public InputDevice input { get; private set; } = new OrGateInput();

	public void SetSourceInputs(List<InputDevice> inputs)
	{
		SourceInputs = inputs;
	}

	public void Init()
	{
		foreach (InputDevice srcInp in SourceInputs)
		{
			srcInp.onTriggered += () =>
			{
				if (!input.IsTriggered)
					input.Trigger();
			};

			srcInp.onUntriggered += () =>
			{
				if (TestNor())
				{
					//Debug.Log("AND satisfied!");
					input.Untrigger();
				}
			};
		}
	}

	bool TestNor() => !TestOr();

	public bool TestOr()
	{
		foreach (var inp in SourceInputs)
		{
			if (inp.IsTriggered)
				return true;
		}
		return false;
	}
}
