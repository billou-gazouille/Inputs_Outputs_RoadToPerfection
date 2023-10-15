
using UnityEngine;

public class OrGateMB : MultiInputOutputDeviceMB
{
    OrGate ioOr = new OrGate();
	public override MultiInputOutputDevice multiIODevice => ioOr;
}
