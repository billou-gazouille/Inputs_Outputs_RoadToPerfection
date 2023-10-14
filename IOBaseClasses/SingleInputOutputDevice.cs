
public abstract class SingleInputOutputDevice : InputOutputDevice
{
	public InputDevice SourceInput { get; protected set; }   // a button for example
	//public OutputDevice output { get; } = new IO_OutputDevice();   // intermediate
	public OutputDevice output { get; }   // intermediate

	public void SetupSourceInput(InputDevice srcInput)
	{
		SourceInput = srcInput;

		SourceInput.onTriggered += OnSourceInputTriggered;
		SourceInput.onUntriggered += OnSourceInputUntriggered;
	}
}
