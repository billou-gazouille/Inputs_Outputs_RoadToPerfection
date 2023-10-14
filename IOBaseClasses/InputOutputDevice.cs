using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputOutputDevice
{
	public class IO_InputDevice : InputDevice { }
	public class IO_OutputDevice : OutputDevice { }

	public InputDevice SourceInput { get; protected set; }   // a button for example
	public OutputDevice output { get; } = new IO_OutputDevice();   // intermediate
	public InputDevice input { get; } = new IO_InputDevice(); // NOT the source input !!

	protected abstract void OnSourceInputTriggered();
	protected abstract void OnSourceInputUntriggered();

	public virtual void Init() { }

	
	public void SetupSourceInput(InputDevice input)
	{
		SourceInput = input;

		SourceInput.onTriggered += () =>
		{
			OnSourceInputTriggered();
		};

		SourceInput.onUntriggered += () =>
		{
			OnSourceInputUntriggered();
		};
	}
	



	/*
	public void Init()
	{
		SourceInput.onTriggered += () =>
		{
			OnSourceInputTriggered();
		};

		SourceInput.onUntriggered += () =>
		{
			OnSourceInputUntriggered();
		};
	}
	*/
}
