
public abstract class SingleInputOutputDevice : InputOutputDevice
{
	public InputDevice SourceInput { get; protected set; }   // a button for example
	public OutputDevice output { get; } = new IO_OutputDevice();   // intermediate

	public void SetSourceInputDevice(InputDevice srcInput)
	{
		SourceInput = srcInput;
		SourceInput.onTriggered += OnSourceInputTriggered;
		SourceInput.onUntriggered += OnSourceInputUntriggered;
		output.SetInputDevice(SourceInput);
	}
}
