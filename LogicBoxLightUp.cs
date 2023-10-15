
using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class LogicBoxLightUp : MonoBehaviour
{
	InputDevice inputDevice;

	[SerializeField] InputDeviceMB inputDeviceMB;
	[SerializeField] Color color;
	[SerializeField] float intensity;

	Renderer _rend;
	Renderer Rend
	{
		get
		{
			if (_rend == null)
				_rend = GetComponent<Renderer>();
			return _rend;
		}
	}

	void Awake()
	{
		Rend.material = new Material(Rend.material);
		Rend.material.EnableKeyword("_EMISSION");
		Rend.material.SetColor("_EmissionColor", color * intensity);
		//LightOff();
	}

	void Start()
	{
		if (inputDeviceMB == null)
			return;

		inputDevice = inputDeviceMB.inputDevice;
		inputDevice.onTriggered += LightOn;
		inputDevice.onUntriggered += LightOff;

		if (inputDeviceMB.inputDevice.IsTriggered)
			LightOn();
		else
			LightOff();
	}

	void LightOn() => Rend.material.EnableKeyword("_EMISSION");
	void LightOff() => Rend.material.DisableKeyword("_EMISSION");
}
