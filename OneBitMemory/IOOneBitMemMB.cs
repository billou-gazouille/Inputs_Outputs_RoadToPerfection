
using UnityEngine;

public class IOOneBitMemMB : SingleInputOutputDeviceMB
{
	IOOneBItMem ioOneBItMem	= new IOOneBItMem();
	public override SingleInputOutputDevice singleIODevice => ioOneBItMem;
}
