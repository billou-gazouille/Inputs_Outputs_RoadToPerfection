using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class IODevicesBinding : MonoBehaviour
{
	public static IODevicesBinding Instance { get; private set; } = null;
	[SerializeField] Transform playerCamTf;


	InputDevice currentSelectedInputDevice = null;
	OutputDevice currentSelectedOutputDevice = null;

	InputDevice currentAimedInputDevice = null;
	OutputDevice currentAimedOutputDevice = null;


	[SerializeField] TMP_Text text;

	[SerializeField] RawImage connectIconImg;	// chain (link)
	[SerializeField] RawImage disconnectIconImg;	// scissors

	[SerializeField] Texture2D connectIconRed;
	[SerializeField] Texture2D connectIconGreen;

	List<InputDevice> enabledInputDevices;
	List<OutputDevice> enabledOutputDevices;


	void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(this);
		
		text.gameObject.SetActive(false);
		connectIconImg.enabled = false;
	}

	private void Start()
	{
		enabledInputDevices = InputDevice.allInputDevices.Where(inp => inp.IsUsable).ToList();
		enabledOutputDevices = OutputDevice.allOutputDevices.Where(outp => outp.IsUsable).ToList();
	}


	bool IsPlayerAimingTarget(Vector3 target)
	{
		float distance = Vector3.Distance(playerCamTf.position, target);
		Vector3 playerCamToInput = (target - playerCamTf.transform.position).normalized;
		float dot = Vector3.Dot(playerCamToInput, playerCamTf.forward);
		//float opp = 0.5f;
		float opp = 0.15f;
		float maxAngle = Mathf.Atan(opp / distance);
		float angle = Mathf.Acos(dot);
		return angle < maxAngle;
	}

	InputDevice GetAimedInput()
	{
		foreach (InputDevice input in enabledInputDevices)
		{
			Vector3 inputPos = (Vector3)input.WorldPosition;
			if (IsPlayerAimingTarget(inputPos))
				return input;
		}
		return null;
	}

	OutputDevice GetAimedOutput()
	{
		foreach (OutputDevice output in enabledOutputDevices)
		{
			Vector3 outputPos = (Vector3)output.WorldPosition;
			if (IsPlayerAimingTarget(outputPos))
				return output;
		}
		return null;
	}


	//void UpdateSelectedOutput()	=> currentSelectedOutputDevice = GetAimedOutput();
	//void UpdateSelectedInput() => currentSelectedInputDevice = GetAimedInput();

	void UpdateAimedInput()	=> currentAimedInputDevice = GetAimedInput();
	void UpdateAimedOutput() => currentAimedOutputDevice = GetAimedOutput();


	void UpdateAimText()
	{
		if (currentAimedInputDevice != null)
		{
			if (!text.gameObject.activeSelf)
				text.gameObject.SetActive(true);
			text.text = "Input";
		}
		else if (currentAimedOutputDevice != null)
		{
			if (!text.gameObject.activeSelf)
				text.gameObject.SetActive(true);
			text.text = "Output";
		}
		else if (text.gameObject.activeSelf)
			text.gameObject.SetActive(false);
	}

	void UpdateConnectUI()
	{
		//UpdateAimText();

		if (currentSelectedInputDevice == null)
		{
			if (currentAimedInputDevice != null)
			{
				if (!connectIconImg.enabled)
					connectIconImg.enabled = true;
			}
			else
			{
				if (connectIconImg.enabled)
					connectIconImg.enabled = false;
			}
		}

		if (Mouse.current.leftButton.isPressed)
		{
			if (currentSelectedInputDevice != null)
			{				
				float freq = 2;
				float val = 1f + 0.2f * Mathf.Sin(Time.time * 2f * Mathf.PI * freq);
				connectIconImg.transform.localScale = new Vector3(val, val, 1f);

				if (currentAimedOutputDevice != null)
					connectIconImg.texture = connectIconGreen;
				else
					connectIconImg.texture = connectIconRed;
			}	
		}
	}

	void UpdateDisconnectUI()
	{
		if (currentAimedOutputDevice != null)
		{
			if (currentAimedOutputDevice.connectedInputDevice != null)
			{
				if (!disconnectIconImg.enabled)
					disconnectIconImg.enabled = true;
			}
		}
		else if (disconnectIconImg.enabled)
			disconnectIconImg.enabled = false;
	}


	void Update()
	{
		UpdateAimedInput();
		UpdateAimedOutput();

		UpdateConnectUI();
		UpdateDisconnectUI();

		if (Mouse.current.leftButton.wasPressedThisFrame)	// press on input
		{
			currentSelectedInputDevice = currentAimedInputDevice;
		}

		if (Mouse.current.leftButton.wasReleasedThisFrame)	 // release on output
		{
			currentSelectedOutputDevice = currentAimedOutputDevice;

			if (currentSelectedInputDevice != null && currentSelectedOutputDevice != null)
			{
				currentSelectedOutputDevice.SetInputDevice(currentSelectedInputDevice);
				//Debug.Log(currentSelectedOutputDevice);
				//Debug.Log(currentSelectedOutputDevice.connectedInputDevice);
			}

			currentSelectedInputDevice = null;
			currentSelectedOutputDevice = null;	
		}


		if (Mouse.current.rightButton.wasPressedThisFrame)   // press on output
		{
			if (currentAimedOutputDevice != null)
			{
				if (currentAimedOutputDevice.connectedInputDevice != null)
					currentAimedOutputDevice.SetInputDevice(null);
			}
		}
	}
}
