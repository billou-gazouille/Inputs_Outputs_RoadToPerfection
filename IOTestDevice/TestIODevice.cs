
using System;

public class TestIODevice : SingleInputOutputDevice
{
	protected override void OnSourceInputTriggered() => input.Trigger();
	protected override void OnSourceInputUntriggered() => input.Untrigger();
}
