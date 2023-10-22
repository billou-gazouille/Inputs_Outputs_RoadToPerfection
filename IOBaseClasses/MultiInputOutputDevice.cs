
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class MultiInputOutputDevice : InputOutputDevice
{
	public List<OutputDevice> outputs { get; } = new List<OutputDevice>();   // intermediate

	public IO_OutputDevice AddNewOutput()
	{
		IO_OutputDevice ioOutput = new IO_OutputDevice(this);
		ioOutput.WorldPosition = OutputsPos;
		outputs.Add(ioOutput);
		return ioOutput;
	}
	public void RemoveOutput(OutputDevice output) => outputs.Remove(output);

	public Vector3 OutputsPos { get; set; }
}
