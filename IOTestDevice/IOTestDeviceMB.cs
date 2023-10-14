
using UnityEngine;

public class IOTestDeviceMB : SingleInputOutputDeviceMB
{
	IOTestDevice ioTestDevice = new IOTestDevice();
	public override SingleInputOutputDevice singleIODevice => ioTestDevice;
}
