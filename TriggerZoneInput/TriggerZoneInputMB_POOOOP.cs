
using UnityEngine;

public class TriggerZoneInputMB_POOOOP : InputDeviceMB
{
	TriggerZoneInput_POOP triggerZoneInput;
	public override InputDevice inputDevice => triggerZoneInput;

	[SerializeField] Vector3 size;
	[SerializeField] float range = 2f;

	[SerializeField] Collider otherCollider;

	void Awake()
	{
		//ITriggerZone triggerZone = new BoxColliderTriggerZone(gameObject, size, otherCollider);
		ITriggerZone triggerZone = new DistanceTriggerZone(gameObject, otherCollider.transform, range);
		triggerZoneInput = new TriggerZoneInput_POOP(triggerZone);
	}
}
