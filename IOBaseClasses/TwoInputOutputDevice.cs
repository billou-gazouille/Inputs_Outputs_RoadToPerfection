
using UnityEngine;

public abstract class TwoInputOutputDevice : InputOutputDevice
{
	public IO_OutputDevice outputA { get; } = new IO_OutputDevice();   // intermediate
	public IO_OutputDevice outputB { get; } = new IO_OutputDevice();   // intermediate
}
