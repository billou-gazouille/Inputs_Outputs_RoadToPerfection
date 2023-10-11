using System;
using UnityEngine;

public class BoxColliderTriggerZone : ITriggerZone
{
	public BoxColliderTriggerZone(GameObject go, Vector3 size, Collider otherCollider)
	{
		this.otherCollider = otherCollider;

		colliderTrigger = go.AddComponent<ColliderTrigger>();
		colliderTrigger.onTriggerEnter += col => NotifyIfOtherColliderEntered(col);
		colliderTrigger.onTriggerExit += col => NotifyIfOtherColliderLeft(col);

		boxCollider = go.AddComponent<BoxCollider>();
		boxCollider.isTrigger = true;
		boxCollider.size = size;
		boxCollider.center = Vector3.zero;  // it's relative to transform
	}

	ColliderTrigger colliderTrigger;

	BoxCollider boxCollider;

	Collider otherCollider;

	public event Action onEntered;
	public event Action onLeft;


	void NotifyIfOtherColliderEntered(Collider other)
	{
		if (other == otherCollider)
			onEntered?.Invoke();
	}
	void NotifyIfOtherColliderLeft(Collider other)
	{
		if (other == otherCollider)
			onLeft?.Invoke();
	}
}
