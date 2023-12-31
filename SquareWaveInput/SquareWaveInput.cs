
public class SquareWaveInput : InputDevice
{
	void Start()
	{
		Timer.Loop(() =>
		{
			Trigger();
			Timer.WaitThenDo(timeOn, () => 
			{
				Untrigger();
				Timer.WaitThenDo(timeOff, () => { });
			});
		}, TimePeriod, immediate: true);
	}

	float timeOn;
	float timeOff;

	public float TimePeriod { get; private set; }
	public float DutyCycle { get; private set; }

	public void Init(float timePeriod, float dutyCycle)
	{
		TimePeriod = timePeriod;
		DutyCycle = dutyCycle;
		timeOn = TimePeriod * DutyCycle;
		timeOff = TimePeriod * (1f - DutyCycle);
		TimersTicker.onCreated += Start;
	}
}
