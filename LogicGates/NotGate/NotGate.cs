

public class NotGate : SingleInputOutputDevice
{
	protected override void OnSourceInputTriggered() => input.Untrigger();
	protected override void OnSourceInputUntriggered() => input.Trigger();

	public override void Init()
	{
		if (!SourceInput.IsTriggered)
			input.Trigger();
		/*
		if (SourceInput.IsTriggered)
			input.Untrigger();
		else
			input.Trigger();
		*/
		//input.Untrigger();
	}
}
