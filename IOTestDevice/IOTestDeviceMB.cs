using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOTestDeviceMB : InputOutputDeviceMB
{
	IOTestDevice ioTestDevice = new IOTestDevice();
	public override InputOutputDevice inputOutputDevice => ioTestDevice;
}
