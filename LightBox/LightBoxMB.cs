using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBoxMB : OutputDeviceMB, ILightBox
{
	LightBox lighttt;

	public override OutputDevice outputDevice => lighttt;

	Renderer rend;

	[SerializeField] Color color;
	[SerializeField] float intensity;

	//void Start()
	void Awake()
	{
		lighttt = new LightBox(this);

		rend = GetComponent<Renderer>();
		rend.material = new Material(rend.material);
		rend.material.EnableKeyword("_EMISSION");
		rend.material.SetColor("_EmissionColor", color * intensity);
		TurnOff();
	}

	public void TurnOn() => rend.material.EnableKeyword("_EMISSION");
	public void TurnOff() => rend.material.DisableKeyword("_EMISSION");
}
