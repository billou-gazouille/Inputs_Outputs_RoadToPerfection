
public abstract class InputOutputDevice
{
	public class IO_InputDevice : InputDevice { }
	public class IO_OutputDevice : OutputDevice { }

	public InputDevice input { get; } = new IO_InputDevice(); // NOT the source input !!

	protected abstract void OnSourceInputTriggered();
	protected abstract void OnSourceInputUntriggered();

	public virtual void Init() { }
}
