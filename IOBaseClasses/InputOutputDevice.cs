
public abstract class InputOutputDevice
{
	public sealed class IO_InputDevice : InputDevice { }
	public sealed class IO_OutputDevice : OutputDevice
	{
		public IO_OutputDevice(InputOutputDevice ioDevice) => inputOutputDevice = ioDevice;
		public InputOutputDevice inputOutputDevice { get; }    // the IO device to which it belongs
		protected override void Activate() => inputOutputDevice.OnOutputActivated();
		protected override void Deactivate() => inputOutputDevice.OnOutputDeactivated();
	}

	public InputDevice input { get; } = new IO_InputDevice(); // NOT the source input !!

	protected virtual void OnOutputActivated() { }
	protected virtual void OnOutputDeactivated() { }

	public virtual void Initialise() { }
}
