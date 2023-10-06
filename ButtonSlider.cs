
using UnityEngine;
using UnityEngine.UI;

public class ButtonSlider : MonoBehaviour
{
	[SerializeField] TimerButtonMB buttonMB;
	TimerButton button;

	[SerializeField] Slider slider;
	[SerializeField] Image sliderFillImg;

	private void Start()
	{
		button = buttonMB.timerButton;
	}

	void Update()
	{
		var percentangeLeft = button.timer.RemainingTime / button.Delay;
		slider.value = percentangeLeft;
		sliderFillImg.color = Color.Lerp(Color.red, Color.green, percentangeLeft);
	}
}