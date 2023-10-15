
using UnityEngine;

public class NotGateMB : SingleInputOutputDeviceMB
{
	NotGate notGate = new NotGate();
	public override SingleInputOutputDevice singleIODevice => notGate;
}
