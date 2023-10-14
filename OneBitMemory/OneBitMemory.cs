
using UnityEngine;

public class OneBitMemory
{
	class OneBitMemoryOutput : OutputDevice { }
	class OneBitMemoryInput : InputDevice { }

	public InputDevice SourceInput { get; private set; }   // a button for example
	public OutputDevice output { get; private set; } = new OneBitMemoryOutput();   // intermediate
	public InputDevice input { get; private set; } = new OneBitMemoryInput();  // NOT the source input !!

	public bool State { get; private set; } = false;
	//public bool State { get; private set; } = false;

	public void SetSourceInput(InputDevice input)
	{
		SourceInput = input;
	}

	public void Init()
	{
		SourceInput.onTriggered += () =>
		{
			if (State)
			{
				State = false;
				input.Untrigger();
				//input.Trigger();
			}
			else
			{
				State = true;
				input.Trigger();
				//input.Untrigger();
			}
		};

		// no onUntriggered
	}
}
