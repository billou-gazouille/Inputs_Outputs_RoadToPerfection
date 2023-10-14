
using UnityEngine;

public class StateInputMB : InputDeviceMB
{
	StateInput stateInput = new StateInput();
	public override InputDevice inputDevice => stateInput;

	[SerializeField] bool state;

	void OnValidate()
	{
		if (state && !stateInput.IsTriggered)
			stateInput.Trigger();
		else if (!state && stateInput.IsTriggered)
			stateInput.Untrigger();
	}
}
