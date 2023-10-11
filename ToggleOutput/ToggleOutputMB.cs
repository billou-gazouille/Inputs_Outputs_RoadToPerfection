
using UnityEngine;

public class ToggleOutputMB : OutputDeviceMB
{
	[SerializeField] InputDeviceMB inputMB;
	[SerializeField] OutputDeviceMB outputMB1;
	[SerializeField] OutputDeviceMB outputMB2;

	ToggleOutput toggleOutput;

	public override OutputDevice outputDevice => toggleOutput;

	void Awake()
	{
		toggleOutput = new ToggleOutput(inputMB.inputDevice, 
			outputMB1.outputDevice, outputMB2.outputDevice);
	}
}
