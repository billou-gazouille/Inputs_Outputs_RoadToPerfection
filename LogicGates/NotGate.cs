using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotGate
{
	class NotGateInput : InputDevice { }

	public InputDevice SourceInput { get; private set; }
	public InputDevice input { get; private set; } = new NotGateInput();  // NOT the source input !!

	public void SetSourceInput(InputDevice input)
	{
		SourceInput = input;
	}

	public void Init()
	{
		SourceInput.onTriggered += () =>
		{
			input.Untrigger();
		};

		SourceInput.onUntriggered += () =>
		{
			input.Trigger();
		};

		//if (TestNot())
			//input.Untrigger();
	}

	
	public bool TestNot()
	{
		return !SourceInput.IsTriggered;
	}
	
}
