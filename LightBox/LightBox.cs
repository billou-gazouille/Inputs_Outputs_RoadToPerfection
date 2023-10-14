
using UnityEngine;

public class LightBox : OutputDevice
{
	public LightBox(ILightBox lightBox) => this.lightBox = lightBox;
	public ILightBox lightBox { get; private set; }
	//public ILightBox lb { get; set; }
	public Color color { get; private set; }
	public float Intenity { get; private set; }

	protected override void Activate() => lightBox.TurnOn();
	protected override void Deactivate() => lightBox.TurnOff();
	//protected override void BehaviourIfNullInput() => lightBox.TurnOff();
}
