
using UnityEngine;

public class TestInputMB : InputDeviceMB
{
    TestInput testInput = new TestInput();

	[SerializeField] bool triggerState = false;
	public override InputDevice inputDevice => testInput;

	void OnValidate()
	{
		if (triggerState && !testInput.IsTriggered)
		{
			Debug.Log($"TestInput '{name}': triggerState ON", this);
			testInput.Trigger();
		}
		else if (!triggerState && testInput.IsTriggered)
		{
			Debug.Log($"TestInput '{name}': triggerState OFF", this);
			testInput.Untrigger();
		}
	}
}
