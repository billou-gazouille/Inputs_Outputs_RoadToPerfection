
public abstract class SingleInputOutputDevice : InputOutputDevice
{
	public IO_OutputDevice output { get; set; } = new IO_OutputDevice();   // intermediate
}
