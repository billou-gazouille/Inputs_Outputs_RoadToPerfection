
using UnityEngine;

//public class IONot : SingleInputOutputDevice
public class IONot : InputOutputDevice
{
	protected override void OnSourceInputTriggered() => input.Untrigger();
	protected override void OnSourceInputUntriggered() => input.Trigger();

	public override void Init()
	{
		if (!SourceInput.IsTriggered)
			input.Trigger();
	}
}
