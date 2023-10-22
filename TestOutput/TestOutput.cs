
using UnityEngine;

public class TestOutput : OutputDevice
{
	protected override void OnActivate() => Debug.Log("Activated !");
	protected override void OnDeactivate() => Debug.Log("Deactivated !");
}
