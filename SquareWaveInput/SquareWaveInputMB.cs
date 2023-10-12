
using UnityEngine;

public class SquareWaveInputMB : InputDeviceMB
{
	[SerializeField] float timePeriod;
	[SerializeField] [Range(0.01f, 0.99f)] float dutyCycle = 0.5f;

	public SquareWaveInput squareWaveInput { get; private set; }
	public override InputDevice inputDevice => squareWaveInput;

	void Awake()
	{
		squareWaveInput = new SquareWaveInput(timePeriod, dutyCycle);
	}
}
