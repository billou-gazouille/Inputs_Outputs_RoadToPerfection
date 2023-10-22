
using System;
using UnityEngine;

public class TimerButtonMB : InputDeviceMB 
{
	//public TimerButton timerButton { get; private set; }
	public TimerButton timerButton { get; private set; } = new TimerButton();

	public override InputDevice inputDevice => timerButton;

	[SerializeField] float delay;

	public override void InitInputDevice()
	{
		timerButton.Init(delay);
	}
}
