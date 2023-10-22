
using System;

public class TestIODevice : SingleInputOutputDevice
{
	protected override void OnOutputActivated() => input.Trigger();
	protected override void OnOutputDeactivated() => input.Untrigger();
}
