using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputOutputLineRenderer : MonoBehaviour
{
	[SerializeField] Material dashedLineMaterial;

	float lineWidth = 0.02f;	
	float lineDashPeriod = 0.2f; // dash every ... distance unit

	Dictionary<OutputDevice, LineRenderer> ioLines = new Dictionary<OutputDevice, LineRenderer>();


	void Awake()
	{
		OutputDevice.onActivated += HighlightIOLink;

		OutputDevice.onDeactivated += UnhighlightIOLink;


		OutputDevice.onRegisteredInput += (OutputDevice output, InputDevice input) =>
		{
			
			GameObject lineGO = new GameObject($"IO-line: {output} - {input}");
			lineGO.transform.parent = transform;
			LineRenderer lr = lineGO.AddComponent<LineRenderer>();
			ioLines.Add(output, lr);
			Vector3 inputPos = (Vector3)input.WorldPosition;
			Vector3 outputPos = (Vector3)output.WorldPosition;
			lr.positionCount = 2;
			lr.SetPosition(0, inputPos);
			lr.SetPosition(1, outputPos);
			lr.startWidth = lineWidth;
			lr.material = new Material(dashedLineMaterial);

			float ioDistance = Vector3.Distance(inputPos, outputPos);
			Vector2 vec = new Vector2(ioDistance / lineDashPeriod, 1f);
			//Vector2 vec = new Vector2(100f, 100f);
			lr.material.SetTextureScale("_BaseMap", vec);
		};
	}

	void HighlightIOLink(OutputDevice output)
	{
		LineRenderer lineRenderer = ioLines[output];
		lineRenderer.material.EnableKeyword("_EMISSION");
	}

	void UnhighlightIOLink(OutputDevice output)
	{
		LineRenderer lineRenderer = ioLines[output];
		lineRenderer.material.DisableKeyword("_EMISSION");
	}
}
