
using UnityEngine;

public class OneBitMemoryMB : SingleInputOutputDeviceMB
{
	OneBitMemory oneBitMemory = new OneBitMemory();
	public override SingleInputOutputDevice singleIODevice => oneBitMemory;
}
