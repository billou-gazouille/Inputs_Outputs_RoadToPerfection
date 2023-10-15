
public class Delayer : SingleInputOutputDevice
{
	public Delayer(float delay) => Delay = delay > 0 ? delay : 5f;
	public float Delay { get; private set; }

	protected override void OnSourceInputTriggered()
	{
		Timer.WaitThenDo(Delay, () => input.Trigger());
	}

	protected override void OnSourceInputUntriggered()
	{
		Timer.WaitThenDo(Delay, () => input.Untrigger());
	}
}
