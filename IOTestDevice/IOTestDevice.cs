
using System;

public class IOTestDevice : SingleInputOutputDevice
{
	protected override void OnSourceInputTriggered() => input.Trigger();
	protected override void OnSourceInputUntriggered() => input.Untrigger();
}
