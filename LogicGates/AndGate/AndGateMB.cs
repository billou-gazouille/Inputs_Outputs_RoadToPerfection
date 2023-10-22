
using UnityEngine;

public class AndGateMB : TwoInputOutputDeviceMB
{
	AndGate andGate = new AndGate();
	public override TwoInputOutputDevice twoIODevice => andGate;
}
