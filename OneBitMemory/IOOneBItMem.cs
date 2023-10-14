
public class IOOneBItMem : SingleInputOutputDevice
{
	public bool State { get; private set; } = false;  // 1 bit

	protected override void OnSourceInputTriggered()
	{
		if (State)
		{
			State = false;
			input.Untrigger();
		}
		else
		{
			State = true;
			input.Trigger();
		}
	}

	protected override void OnSourceInputUntriggered() { }
}
