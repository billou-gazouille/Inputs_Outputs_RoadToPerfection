
public class TimerButton : InputDevice
{
	public Timer timer { get; private set; }
	public float Delay { get; private set; }
	float defaultDelay = 5f;

	public void Init(float delay)
    {
		Delay = delay > 0 ? delay : defaultDelay;
		timer = new Timer(Delay);
		timer.onFinished = () =>
		{
			Untrigger();
			timer.Reset();
		};
	}

	public void Press()
	{
		Trigger();
		timer.Start();
	}
}
