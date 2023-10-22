
public class OneBitMemory : SingleInputOutputDevice
{
	public bool State { get; private set; } = false;  // 1 bit

	protected override void OnOutputActivated()
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

	protected override void OnOutputDeactivated() { }
}
