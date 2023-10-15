
using UnityEngine;

public class TestIODeviceMB : SingleInputOutputDeviceMB
{
	TestIODevice ioTestDevice = new TestIODevice();
	public override SingleInputOutputDevice singleIODevice => ioTestDevice;
}
