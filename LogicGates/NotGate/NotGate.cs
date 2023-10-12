
using UnityEngine;

public class NotGate
{
	class NotGateOutput : OutputDevice { }
	class NotGateInput : InputDevice { }

	public InputDevice SourceInput { get; private set; }   // a button for example
	public OutputDevice output { get; private set; } = new NotGateOutput();	  // intermediate
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
