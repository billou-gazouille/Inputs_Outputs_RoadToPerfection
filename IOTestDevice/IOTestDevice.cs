
using UnityEngine;

public class IOTestDevice : InputOutputDevice
{
	protected override void OnSourceInputTriggered() => input.Trigger();
	protected override void OnSourceInputUntriggered() => input.Untrigger();
}
