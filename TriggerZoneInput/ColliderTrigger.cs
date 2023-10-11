using System;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
	public event Action<Collider> onTriggerEnter;
	public event Action<Collider> onTriggerExit;

	void OnTriggerEnter(Collider other) => onTriggerEnter?.Invoke(other);

	void OnTriggerExit(Collider other) => onTriggerExit?.Invoke(other);
}
