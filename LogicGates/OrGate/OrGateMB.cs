
using UnityEngine;

public class OrGateMB : TwoInputOutputDeviceMB
{
    OrGate orGate = new OrGate();
	public override TwoInputOutputDevice twoIODevice => orGate;
}
