
using System.Collections.Generic;
using UnityEngine;

public class AndGate
{
	class AndGateInput : InputDevice { }

    public List<InputDevice> SourceInputs { get; private set; }

	public InputDevice input { get; private set; } = new AndGateInput();
	
	public void SetInputs(List<InputDevice> inputs)
    {
		SourceInputs = inputs;
    }

	public void Init()
	{
		foreach (InputDevice srcInp in SourceInputs)
		{
			srcInp.onTriggered += () =>
			{
				//Debug.Log("An input from an AND Gate was triggered!");
				if (TestAnd())
				{
					//Debug.Log("AND satisfied!");
					input.Trigger();
				}
			};

			srcInp.onUntriggered += () =>
			{
				//Debug.Log("An input from an AND Gate was untriggered!");
				if (input.IsTriggered)
					input.Untrigger();
			};
		}
	}

	public bool TestAnd()
	{
		foreach (var inp in SourceInputs)
		{
			if (!inp.IsTriggered)
				return false;
		}
		return true;
	}
}
