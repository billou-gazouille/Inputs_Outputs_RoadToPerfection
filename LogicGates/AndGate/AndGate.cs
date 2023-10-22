using UnityEngine;

public class AndGate : TwoInputOutputDevice
{
	protected override void OnOutputActivated()
	{
		//Debug.Log("AND: OnOutputActivated");
		if (TestAnd())
			input.Trigger();
	}

	protected override void OnOutputDeactivated()
	{
		if (input.IsTriggered)
			input.Untrigger();
	}

	bool TestAnd()
	{
		return outputA.IsActive && outputB.IsActive;
	}
}
