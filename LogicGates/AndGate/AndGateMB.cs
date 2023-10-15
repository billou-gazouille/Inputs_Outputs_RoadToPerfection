
using UnityEngine;

public class AndGateMB : MultiInputOutputDeviceMB
{
	AndGate andGate = new AndGate();
	public override MultiInputOutputDevice multiIODevice => andGate;
}
