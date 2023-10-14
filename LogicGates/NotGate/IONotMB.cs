
using UnityEngine;

public class IONotMB : SingleInputOutputDeviceMB
{
	IONot ioNot	= new IONot();
	public override SingleInputOutputDevice singleIODevice => ioNot;
}
