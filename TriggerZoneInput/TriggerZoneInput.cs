using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneInput : InputDevice
{
    // Box shape

    public TriggerZoneInput(Transform centerTf, Vector3 size)
    {
		CenterTransform = centerTf;
        Size = size;
    }

    public Transform CenterTransform {  get; set; }
    public Vector3 Size {  get; set; }
}
