
using UnityEngine;

public class IODelayerMB : SingleInputOutputDeviceMB
{
	IODelayer ioDelayer;
	public override SingleInputOutputDevice singleIODevice => ioDelayer;

	[SerializeField] float delay;

	void Awake()
	{
		ioDelayer = new IODelayer(delay);
	}
}
