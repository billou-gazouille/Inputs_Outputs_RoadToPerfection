
using UnityEngine;

public class Delayer
{
	class DelayerInput : InputDevice { }

	public InputDevice SourceInput { get; private set; }
	public InputDevice input { get; private set; } = new DelayerInput();  // NOT the source input !!

	public float Delay { get; private set; }

	public void SetSourceInput(InputDevice input)
	{
		SourceInput = input;
	}

	public void Init(float delay)
	{
		Delay = delay;

		SourceInput.onTriggered += () =>
		{
			//Debug.Log("Triggered");
			Timer.WaitThenDo(Delay, () => input.Trigger());
		};

		SourceInput.onUntriggered += () =>
		{
			//Debug.Log("Untriggered");
			Timer.WaitThenDo(Delay, () => input.Untrigger());
		};
	}
}
