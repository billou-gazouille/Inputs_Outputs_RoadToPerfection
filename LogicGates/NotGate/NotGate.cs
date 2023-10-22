

public class NotGate : SingleInputOutputDevice
{
	protected override void OnOutputActivated() => input.Untrigger();
	protected override void OnOutputDeactivated() => input.Trigger();

	public override void Initialise()
	{
		if (!output.IsActive)
			input.Trigger();
	}
}
