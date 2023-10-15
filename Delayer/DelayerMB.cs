
using UnityEngine;

public class DelayerMB : SingleInputOutputDeviceMB
{
	Delayer ioDelayer;
	public override SingleInputOutputDevice singleIODevice => ioDelayer;

	[SerializeField] float delay;

	void Awake()
	{
		ioDelayer = new Delayer(delay);
	}
}
