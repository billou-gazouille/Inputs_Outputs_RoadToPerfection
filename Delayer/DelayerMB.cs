
using UnityEngine;

public class DelayerMB : SingleInputOutputDeviceMB
{
	Delayer delayer;
	public override SingleInputOutputDevice singleIODevice => delayer;

	[SerializeField] float delay;

	void Awake()
	{
		delayer = new Delayer(delay);
	}
}
