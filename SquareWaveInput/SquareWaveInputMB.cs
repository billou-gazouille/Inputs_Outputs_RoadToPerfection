
using UnityEngine;

public class SquareWaveInputMB : InputDeviceMB
{
	[SerializeField] float timePeriod;
	[SerializeField] [Range(0.01f, 0.99f)] float dutyCycle = 0.5f;

	public SquareWaveInput squareWaveInput { get; private set; } = new SquareWaveInput();
	public override InputDevice inputDevice => squareWaveInput;

	public override void InitInputDevice()
	{
		squareWaveInput.Init(timePeriod, dutyCycle);
	}
}
