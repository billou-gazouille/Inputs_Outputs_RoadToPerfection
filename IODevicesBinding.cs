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
	public event Action<MonoBehaviour> onIODeviceSelected;

	List<InputDeviceMB> inputDeviceMBs;
	List<OutputDeviceMB> outputDeviceMBs;
	List<InputOutputDeviceMB> inputOutputDeviceMBs;

	List<MonoBehaviour> allIODevicesMBs = new List<MonoBehaviour>();

	MonoBehaviour currentTargetIODevice = null;

	// connect terminalA to terminalB
	MonoBehaviour terminalA = null;
	MonoBehaviour terminalB = null;

	bool canLinkAandB = false;

	[SerializeField] TMP_Text text;

	//[SerializeField] Image linkIconImg;
	[SerializeField] RawImage linkIconImg;
	[SerializeField] Texture2D linkIconRed;
	[SerializeField] Texture2D linkIconGreen;

	void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(this);

		inputDeviceMBs = FindObjectsOfType<InputDeviceMB>().ToList();
		outputDeviceMBs = FindObjectsOfType<OutputDeviceMB>().ToList();
		inputOutputDeviceMBs = FindObjectsOfType<InputOutputDeviceMB>().ToList();

		allIODevicesMBs.AddRange(inputDeviceMBs);
		allIODevicesMBs.AddRange(outputDeviceMBs);
		allIODevicesMBs.AddRange(inputOutputDeviceMBs);

		//foreach (var device in allIODevicesMBs)
			//Debug.Log(device.name);

		text.gameObject.SetActive(false);

		linkIconImg.enabled = false;
	}

	void Update()
	{
		if (currentTargetIODevice != null)
			currentTargetIODevice = null;

		foreach (var device in allIODevicesMBs)
		{
			float distance = Vector3.Distance(playerCamTf.position, device.transform.position);			 
			Vector3 playerCamToInteractable = (device.transform.position - playerCamTf.transform.position).normalized;
			float dot = Vector3.Dot(playerCamToInteractable, playerCamTf.forward);
			float opp = 0.5f;
			float maxAngle = Mathf.Atan(opp/distance);
			float angle = Mathf.Acos(dot);

			if (angle < maxAngle)
			{
				//Debug.Log(maxAngle*Mathf.Rad2Deg);
				currentTargetIODevice = device;
				//text.text = device.name + "\nConnect [Mouse Left Button]";
				bool isInput = currentTargetIODevice is InputDeviceMB;
				bool isOutput = currentTargetIODevice is OutputDeviceMB;
				bool isInputOutput = currentTargetIODevice is InputOutputDeviceMB;
				if (isInputOutput)
					text.text = device.name + "\n(Input-Output)";
				else if (isInput)
					text.text = device.name + "\n(Input)";
				else if (isOutput)
					text.text = device.name + "\n(Output)";
			}
		}


		if (currentTargetIODevice != null)
		{
			if (!text.gameObject.activeSelf)
				text.gameObject.SetActive(true);

			//if (Keyboard.current.eKey.wasPressedThisFrame)
				//onIODeviceSelected?.Invoke(currentTargetIODevice);
			if (Mouse.current.leftButton.wasPressedThisFrame)
			{
				linkIconImg.enabled = true;
				terminalA = currentTargetIODevice;
				//onIODeviceSelected?.Invoke(currentTargetIODevice);
			}
			if (Mouse.current.leftButton.wasReleasedThisFrame)
			{
				linkIconImg.enabled = false;
				terminalB = currentTargetIODevice;
				//onIODeviceSelected?.Invoke(currentTargetIODevice);
				if (terminalA != terminalB)
				{
					/*
					if (terminalA is InputDeviceMB && terminalB is OutputDeviceMB ||
						terminalA is OutputDeviceMB && terminalB is InputDeviceMB ||
						terminalA is InputDeviceMB && terminalB is InputOutputDeviceMB ||
						terminalA is InputOutputDeviceMB && terminalB is InputDeviceMB ||
						terminalA is InputOutputDeviceMB && terminalB is OutputDeviceMB ||
						terminalA is OutputDeviceMB && terminalB is InputOutputDeviceMB ||
						terminalA is InputOutputDeviceMB && terminalB is InputOutputDeviceMB ||
						terminalA is InputOutputDeviceMB && terminalB is InputOutputDeviceMB
						)
						Debug.Log("NOICE");
					*/

					/*
					if (terminalA is SingleInputOutputDeviceMB && terminalB is InputDeviceMB)
					{
						Debug.Log("A is SingleInputOutputDeviceMB;    B is InputDeviceMB");
						//((SingleInputOutputDeviceMB)terminalA).singleIODevice.output.SetInputDevice(((InputDeviceMB)terminalB).inputDevice);
					}
					*/

					/*
					if (terminalA is SingleInputOutputDeviceMB && terminalB is InputOutputDeviceMB)
					{
						Debug.Log("A is SingleInputOutputDeviceMB;    B is InputOutputDeviceMB");
						//((SingleInputOutputDeviceMB)terminalA).singleIODevice.output.SetInputDevice(((InputDeviceMB)terminalB).inputDevice);
					}
					else if (terminalA is InputOutputDeviceMB && terminalB is SingleInputOutputDeviceMB)
					{
						Debug.Log("A is InputOutputDeviceMB;    B is SingleInputOutputDeviceMB");
						//((SingleInputOutputDeviceMB)terminalA).singleIODevice.output.SetInputDevice(((InputDeviceMB)terminalB).inputDevice);
					}

					else if (terminalA is OutputDeviceMB && terminalB is InputDeviceMB)
					{
						Debug.Log("A is OutputDeviceMB;    B is InputDeviceMB");
						((OutputDeviceMB)terminalA).SetInputDeviceMB((InputDeviceMB)terminalB);
					}
					else if (terminalA is InputDeviceMB && terminalB is OutputDeviceMB)
					{
						Debug.Log("A is InputDeviceMB;    B is OutputDeviceMB");
						((OutputDeviceMB)terminalB).SetInputDeviceMB((InputDeviceMB)terminalA);
					}
					*/

					if (terminalA is SingleInputOutputDeviceMB && terminalB is SingleInputOutputDeviceMB)
					{
						Debug.Log("A is SingleInputOutputDeviceMB;    B is SingleInputOutputDeviceMB");
						//((SingleInputOutputDeviceMB)terminalA).singleIODevice.output.SetInputDevice(((InputDeviceMB)terminalB).inputDevice);
					}

					else if (terminalA is SingleInputOutputDeviceMB && terminalB is InputDeviceMB)
					{
						Debug.Log("A is SingleInputOutputDeviceMB;    B is InputDeviceMB");
						//((SingleInputOutputDeviceMB)terminalA).singleIODevice.output.SetInputDevice(((InputDeviceMB)terminalB).inputDevice);
					}
					else if (terminalA is InputDeviceMB && terminalB is SingleInputOutputDeviceMB)
					{
						Debug.Log("A is InputDeviceMB;    B is SingleInputOutputDeviceMB");
						//((SingleInputOutputDeviceMB)terminalA).singleIODevice.output.SetInputDevice(((InputDeviceMB)terminalB).inputDevice);
					}

					else if (terminalA is SingleInputOutputDeviceMB && terminalB is OutputDeviceMB)
					{
						Debug.Log("A is SingleInputOutputDeviceMB;    B is OutputDeviceMB");
						//((SingleInputOutputDeviceMB)terminalA).singleIODevice.output.SetInputDevice(((InputDeviceMB)terminalB).inputDevice);
					}
					else if (terminalA is OutputDeviceMB && terminalB is SingleInputOutputDeviceMB)
					{
						Debug.Log("A is OutputDeviceMB;    B is SingleInputOutputDeviceMB");
						//((SingleInputOutputDeviceMB)terminalA).singleIODevice.output.SetInputDevice(((InputDeviceMB)terminalB).inputDevice);
					}

					if (terminalA is MultiInputOutputDeviceMB && terminalB is MultiInputOutputDeviceMB)
					{
						Debug.Log("A is MultiInputOutputDeviceMB;    B is MultiInputOutputDeviceMB");
						//((SingleInputOutputDeviceMB)terminalA).singleIODevice.output.SetInputDevice(((InputDeviceMB)terminalB).inputDevice);
					}

					else if (terminalA is MultiInputOutputDeviceMB && terminalB is InputDeviceMB)
					{
						Debug.Log("A is MultiInputOutputDeviceMB;    B is InputDeviceMB");
						//((SingleInputOutputDeviceMB)terminalA).singleIODevice.output.SetInputDevice(((InputDeviceMB)terminalB).inputDevice);
					}
					else if (terminalA is InputDeviceMB && terminalB is MultiInputOutputDeviceMB)
					{
						Debug.Log("A is InputDeviceMB;    B is MultiInputOutputDeviceMB");
						//((SingleInputOutputDeviceMB)terminalA).singleIODevice.output.SetInputDevice(((InputDeviceMB)terminalB).inputDevice);
					}

					else if (terminalA is MultiInputOutputDeviceMB && terminalB is OutputDeviceMB)
					{
						Debug.Log("A is MultiInputOutputDeviceMB;    B is OutputDeviceMB");
						//((SingleInputOutputDeviceMB)terminalA).singleIODevice.output.SetInputDevice(((InputDeviceMB)terminalB).inputDevice);
					}
					else if (terminalA is OutputDeviceMB && terminalB is MultiInputOutputDeviceMB)
					{
						Debug.Log("A is OutputDeviceMB;    B is MultiInputOutputDeviceMB");
						//((SingleInputOutputDeviceMB)terminalA).singleIODevice.output.SetInputDevice(((InputDeviceMB)terminalB).inputDevice);
					}



					else if (terminalA is InputDeviceMB && terminalB is OutputDeviceMB)
					{
						Debug.Log("A is InputDeviceMB;    B is OutputDeviceMB");
						//((SingleInputOutputDeviceMB)terminalA).singleIODevice.output.SetInputDevice(((InputDeviceMB)terminalB).inputDevice);
					}
					else if (terminalA is OutputDeviceMB && terminalB is InputDeviceMB)
					{
						Debug.Log("A is OutputDeviceMB;    B is InputDeviceMB");
						//((SingleInputOutputDeviceMB)terminalA).singleIODevice.output.SetInputDevice(((InputDeviceMB)terminalB).inputDevice);
					}
				}
			}
		}
		else
		{
			if (text.gameObject.activeSelf)
				text.gameObject.SetActive(false);
		}

		if (Mouse.current.leftButton.isPressed)
		{
			if (linkIconImg.enabled)
			{
				//if (!canLinkAandB)
				linkIconImg.texture = linkIconGreen;
				float freq = 2;
				float val = 1f + 0.2f * Mathf.Sin(Time.time * 2f * Mathf.PI * freq);
				linkIconImg.transform.localScale = new Vector3(val, val, 1f);
			}
		}
	}
}
