
using UnityEngine;

public class DelayerMB : SingleInputOutputDeviceMB
{
	Delayer delayer = new Delayer();
	public override SingleInputOutputDevice singleIODevice => delayer;

	[SerializeField] float delay;

	public override void InitSingleIODevice()
	{
		delayer.Init(delay);
	}
}
