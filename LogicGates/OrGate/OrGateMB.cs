
using UnityEngine;

public class OrGateMB : MultiInputOutputDeviceMB
{
    OrGate orGate = new OrGate();
	public override MultiInputOutputDevice multiIODevice => orGate;
}
