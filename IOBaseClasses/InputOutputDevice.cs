
public abstract class InputOutputDevice
{
	public sealed class IO_InputDevice : InputDevice { }
	public sealed class IO_OutputDevice : OutputDevice
	{
		public InputOutputDevice inputOutputDevice { get; private set; }    // the IO device to which it belongs
		protected sealed override void OnActivate() => inputOutputDevice.OnOutputActivated();
		protected sealed override void OnDeactivate() => inputOutputDevice.OnOutputDeactivated();
		protected sealed override void BehaviourIfNullInput() => Deactivate(); 
		//protected sealed override void BehaviourIfNullInput() { UnityEngine.Debug.Log("OH"); }
		public void Setup(InputOutputDevice ioDevice) => inputOutputDevice = ioDevice;
	}

	public InputDevice input { get; } = new IO_InputDevice(); // NOT the source input !!

	protected virtual void OnOutputActivated() { }
	protected virtual void OnOutputDeactivated() { }

	public virtual void Initialise() { }
}
