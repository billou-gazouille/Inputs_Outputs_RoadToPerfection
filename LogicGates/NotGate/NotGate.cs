

public class NotGate : SingleInputOutputDevice
{
	protected override void OnSourceInputTriggered() => input.Untrigger();
	protected override void OnSourceInputUntriggered() => input.Trigger();

	public override void Initialise()
	{
		if (!SourceInput.IsTriggered)
			input.Trigger();
	}
}
