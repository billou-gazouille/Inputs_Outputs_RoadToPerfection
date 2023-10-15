
using UnityEngine;

public class NotGateMB : SingleInputOutputDeviceMB
{
	NotGate ioNot	= new NotGate();
	public override SingleInputOutputDevice singleIODevice => ioNot;
}
