
using UnityEngine;

public class TriggerZoneInputMB : InputDeviceMB
{
	TriggerZoneInput triggerZoneInput;
	public override InputDevice inputDevice => triggerZoneInput;

	[SerializeField] Vector3 size;

	[SerializeField] Collider playerCollider;

	BoxCollider boxCollider;

	void Awake()
	{
		triggerZoneInput = new TriggerZoneInput(transform, size);

		boxCollider = gameObject.AddComponent<BoxCollider>();
		boxCollider.isTrigger = true;
		boxCollider.size = triggerZoneInput.Size;
		//boxCollider.center = triggerZoneInput.CenterTransform.position;
		boxCollider.center = Vector3.zero;	// it's relative to transform
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
