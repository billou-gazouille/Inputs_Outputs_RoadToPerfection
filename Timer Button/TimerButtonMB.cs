
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TimerButtonMB : InputDeviceMB 
{
	//public TimerButton timerButton { get; private set; }
	public TimerButton timerButton { get; private set; } = new TimerButton();

	public override InputDevice inpDev => timerButton;

	[SerializeField] float delay;

	//void Awake()
	void Start()
	{
		//inputDevice = timerButton;
		timerButton.Init(delay);
		//timerButton.Init();
	}


	/*
	void Update()
	{
		if (Keyboard.current.eKey.wasPressedThisFrame)
		{
			timerButton.Press();
		}
	}
	*/
}
