using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InputOutputLineRenderer : MonoBehaviour
{

	[SerializeField] Material lineMaterial;

	float lineWidth = 0.03f;
	float lineDashPeriod = 0.2f; // dash every ... distance unit

	Dictionary<LineRenderer, IO_Link> IOLines = new Dictionary<LineRenderer, IO_Link>();

	struct IO_Link
	{
		public IO_Link(InputDevice input, OutputDevice output)
		{
			this.input = input;
			this.output = output;
		}

		public InputDevice input;
		public OutputDevice output;
		/*
		public override bool Equals(object obj)
		{
			return input == ((IO_Link)obj).input && output == ((IO_Link)obj).output;
		}
		*/
		public static Action<InputDevice, OutputDevice> onTurnedOn;	// 0 to 1
		public static Action<InputDevice, OutputDevice> onTurnedOff;	// 1 to 0
	}

	void Awake()
	{
		OutputDevice.onRegisteredInput += (OutputDevice output, InputDevice input) =>
		{
			
			GameObject lineGO = new GameObject($"IO-line: {output} - {input}");
			lineGO.transform.parent = transform;
			LineRenderer lr = lineGO.AddComponent<LineRenderer>();
			IO_Link ioLink = new IO_Link(input, output);
			IOLines.Add(lr, ioLink);
			Vector3 inputPos = (Vector3)input.WorldPosition;
			Vector3 outputPos = (Vector3)output.WorldPosition;
			lr.positionCount = 2;
			lr.SetPosition(0, inputPos);
			lr.SetPosition(1, outputPos);
			lr.startWidth = lineWidth;
			lr.material = lineMaterial;

			float ioDistance = Vector3.Distance(inputPos, outputPos);
			Vector2 vec = new Vector2(ioDistance / lineDashPeriod, 1f);
			lr.material.SetTextureScale("_BaseMap", vec);

			//Debug.Log(output.WorldPosition);
			//Debug.Log(input.WorldPosition);

			/*

			IO_Link.onTurnedOn += (InputDevice input, OutputDevice output) =>
			{
				input.onTriggered += () => SetIOLinkColor(ioLink, Color.blue);
			};

			IO_Link.onTurnedOff += (InputDevice input, OutputDevice output) =>
			{
				input.onTriggered += () => SetIOLinkColor(ioLink, Color.black);
			};
			*/
		};
	}


	void SetIOLinkColor(IO_Link ioLink, Color color)
	{
		foreach (var line in IOLines)
		{
			if (line.Value.Equals(ioLink))
				line.Key.material.color = color;
		}
	}

	/*
	void Start()  // not sure if this is reliable
    {
		//var inputs = FindObjectsOfType<InputDeviceMB>().Select(idmb => idmb.inputDevice).ToList();
		var idmbs = FindObjectsOfType<InputDeviceMB>().ToList();
		foreach (var idmb in idmbs)
		{
			Debug.Log($"{idmb.name}; inputDevice: {idmb.inputDevice}", idmb);
		}
	}
	*/
}
