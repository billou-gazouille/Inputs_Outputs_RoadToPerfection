
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TimerButtonMB : InputDeviceMB 
{
	public TimerButton timerButton { get; private set; }
	[SerializeField] float delay;

	void Awake()
	{
		inputDevice = new TimerButton();
		//new TimerButton();
		//new TimerButton();
		//Debug.Log("OKAY");
		timerButton = (TimerButton)inputDevice;
		timerButton.Init(delay);
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
