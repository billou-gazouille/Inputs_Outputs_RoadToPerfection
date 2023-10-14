
using UnityEngine;

public class IONotMB : InputOutputDeviceMB
{
	IONot ioNot	= new IONot();
	public override InputOutputDevice inputOutputDevice => ioNot;
}
