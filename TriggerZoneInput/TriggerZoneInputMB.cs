
using UnityEngine;

public class TriggerZoneInputMB : InputDeviceMB
{
	TriggerZoneInput triggerZoneInput = new TriggerZoneInput();
	public override InputDevice inputDevice => triggerZoneInput;

	[SerializeField] Vector3 size;

	[SerializeField] Collider playerCollider;

	BoxCollider boxCollider;

	public override void InitInputDevice()
	{
		//Debug.Log(this,this);
		triggerZoneInput.Init(transform, size);
		boxCollider = gameObject.AddComponent<BoxCollider>();
		boxCollider.isTrigger = true;
		var s = triggerZoneInput.Size;
		boxCollider.size = s != Vector3.zero ? s : Vector3.one * 2f;
		//boxCollider.center = triggerZoneInput.CenterTransform.position;
		boxCollider.center = Vector3.zero;  // it's relative to transform
	}

	void OnTriggerEnter(Collider other)
	{
		if (other == playerCollider)
		{
			triggerZoneInput.Trigger();
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other == playerCollider)
		{
			triggerZoneInput.Untrigger();
		}
	}
}