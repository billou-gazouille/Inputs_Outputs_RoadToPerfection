using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static InputOutputDevice;

public class IODevicesBinding : MonoBehaviour
{
	public static IODevicesBinding Instance { get; private set; } = null;
	[SerializeField] Transform playerCamTf;


	InputDevice currentSelectedInputDevice = null;
	OutputDevice currentSelectedOutputDevice = null;

	InputDevice currentSelectedPureInputs = null;
	OutputDevice currentSelectedPureOutputs = null;

	InputDevice currentAimedInputDevice = null;
	OutputDevice currentAimedOutputDevice = null;

	InputDevice currentAimedPureInputs = null;
	OutputDevice currentAimedPureOutputs = null;


	[SerializeField] TMP_Text text;

	[SerializeField] RawImage linkIconImg;

	[SerializeField] Texture2D linkIconRed;
	[SerializeField] Texture2D linkIconGreen;

	List<InputDevice> enabledInputDevices;
	List<OutputDevice> enabledOutputDevices;

	List<OutputDevice> enabledPureOutputs;

	List<OutputDevice> enabledSIOOutputs;
	List<OutputDevice> enabledMIOOutputs;

	void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(this);
		
		text.gameObject.SetActive(false);
		linkIconImg.enabled = false;
	}

	private void Start()
	{
		enabledInputDevices = InputDevice.allInputDevices.Where(inp => inp.IsUsable).ToList();
		//Debug.Log(enabledInputDevices.Count);
		enabledOutputDevices = OutputDevice.allOutputDevices.Where(outp => outp.IsUsable).ToList();
		//Debug.Log(enabledOutputDevices.Count);

		/*
		enabledPureOutputs = OutputDevice.allOutputDevices.Where(outp => outp.IsUsable)
			.Where(outp => ! (outp is IO_OutputDevice)).ToList();

		var enabledIOutputs = OutputDevice.allOutputDevices.Where(outp => outp.IsUsable)
			.Where(outp => outp is IO_OutputDevice).ToList();

		enabledSIOOutputs = enabledIOutputs.Where(outp => ((IO_OutputDevice)outp).inputOutputDevice is SingleInputOutputDevice).ToList();
		enabledMIOOutputs = enabledIOutputs.Where(outp => ((IO_OutputDevice)outp).inputOutputDevice is MultiInputOutputDevice).ToList();
		*/
	}


	bool IsPlayerAimingTarget(Vector3 target)
	{
		float distance = Vector3.Distance(playerCamTf.position, target);
		Vector3 playerCamToInput = (target - playerCamTf.transform.position).normalized;
		float dot = Vector3.Dot(playerCamToInput, playerCamTf.forward);
		float opp = 0.5f;
		//float opp = 0.3f;
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


	void UpdateSelectedOutput()	=> currentSelectedOutputDevice = GetAimedOutput();
	void UpdateSelectedInput() => currentSelectedInputDevice = GetAimedInput();

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

	void UpdateAimUI()
	{
		//UpdateAimText();

		if (currentSelectedInputDevice == null)
		{
			if (currentAimedInputDevice != null)
			{
				if (!linkIconImg.enabled)
					linkIconImg.enabled = true;
			}
			else
			{
				if (linkIconImg.enabled)
					linkIconImg.enabled = false;
			}
		}

		if (Mouse.current.leftButton.isPressed)
		{
			if (currentSelectedInputDevice != null)
			{				
				float freq = 2;
				float val = 1f + 0.2f * Mathf.Sin(Time.time * 2f * Mathf.PI * freq);
				linkIconImg.transform.localScale = new Vector3(val, val, 1f);

				if (currentAimedOutputDevice != null)
					linkIconImg.texture = linkIconGreen;
				else
					linkIconImg.texture = linkIconRed;
			}	
		}
	}


	void Update()
	{
		UpdateAimedInput();
		UpdateAimedOutput();

		UpdateAimUI();

		if (Mouse.current.leftButton.wasPressedThisFrame)	// press on input
		{
			//linkIconImg.enabled = true;
			currentSelectedInputDevice = currentAimedInputDevice;
		}

		if (Mouse.current.leftButton.wasReleasedThisFrame)	 // release on output
		{
			//linkIconImg.enabled = false;
			currentSelectedOutputDevice = currentAimedOutputDevice;

			if (currentSelectedInputDevice != null && currentSelectedOutputDevice != null)
			{
				if (currentAimedOutputDevice is InputOutputDevice.IO_OutputDevice)
				{
					var ioOutput = (InputOutputDevice.IO_OutputDevice)currentAimedOutputDevice;
					if (ioOutput.inputOutputDevice is MultiInputOutputDevice)
					{
						var mio = (MultiInputOutputDevice)(ioOutput.inputOutputDevice);
						OutputDevice newOutput = mio.AddNewOutput();
						newOutput.SetInputDevice(currentSelectedInputDevice);
					}
				}
				else
				{
					currentSelectedOutputDevice.SetInputDevice(currentSelectedInputDevice);
				}
				
				//currentSelectedOutputDevice.SetInputDevice(currentSelectedInputDevice);
				Debug.Log(currentSelectedOutputDevice);
				Debug.Log(currentSelectedOutputDevice.connectedInputDevice);
			}

			currentSelectedInputDevice = null;
			currentSelectedOutputDevice = null;	
		}		
	}
}
