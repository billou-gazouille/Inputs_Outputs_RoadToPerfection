
using UnityEngine;

public class IOAndMB : MultiInputOutputDeviceMB
{
	IOAnd ioAnd = new IOAnd();
	public override MultiInputOutputDevice multiIODevice => ioAnd;
}
