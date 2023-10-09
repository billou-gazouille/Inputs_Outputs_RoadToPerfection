
using UnityEngine;
using UnityEngine.InputSystem;

public class TestInputBindV2 : MonoBehaviour
{
	[SerializeField] InputDeviceMB inputMB;
	[SerializeField] OutputDeviceMB outputMB1;
	[SerializeField] OutputDeviceMB outputMB2;


	private void Start()
	{
		//ChangeOutput(true);
	}

	void ChangeOutput(bool isOutputMB1)
	{
		//(isOutputMB1 ? outputMB1 : outputMB2).outputDevice.SetInputDevice(inputMB.inputDevice);
		(isOutputMB1 ? outputMB1 : outputMB2).outputDevice.SetInputDevice(inputMB.inputDevice);
		//(isOutputMB1 ? outputMB2 : outputMB1).outputDevice.SetInputDevice(null);
		(isOutputMB1 ? outputMB2 : outputMB1).outputDevice.SetInputDevice(null);
	}


	void Update()
	{
		if (Keyboard.current.numpad1Key.wasPressedThisFrame)  // bind output 1
		{
			Debug.Log("key 1");
			ChangeOutput(true);
		}

		if (Keyboard.current.numpad2Key.wasPressedThisFrame)  // bind output 2
		{
			Debug.Log("key 2");
			ChangeOutput(false);
		}
	}
}
