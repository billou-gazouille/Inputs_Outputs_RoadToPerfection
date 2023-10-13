
using UnityEngine;

[RequireComponent(typeof(InputDeviceMB))]
[RequireComponent(typeof(Renderer))]

public class LogicBoxLightUp : MonoBehaviour
{
	InputDevice inputDevice;
	Renderer rend;

	void Start()
	{
		inputDevice = GetComponent<InputDeviceMB>().inputDevice;
		rend = GetComponent<Renderer>();

		inputDevice.onTriggered += LightOn;
		inputDevice.onUntriggered += LightOff;

		rend.material = new Material(rend.material);
		rend.material.EnableKeyword("_EMISSION");
		rend.material.SetColor("_EmissionColor", Color.blue * 3f);
		LightOff();
	}

	void LightOn()
	{
		//Debug.Log("noice");
		rend.material.EnableKeyword("_EMISSION");
	}
	void LightOff()
	{
		rend.material.DisableKeyword("_EMISSION");
	}
}
