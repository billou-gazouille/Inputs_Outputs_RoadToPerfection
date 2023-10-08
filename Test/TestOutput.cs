using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOutput : OutputDevice
{
	protected override void Activate() => Debug.Log("Activated !");
	protected override void Deactivate() => Debug.Log("Deactivated !");
}
