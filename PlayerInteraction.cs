using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
	public static PlayerInteraction Instance { get; private set; } = null;
	[SerializeField] Transform playerCamTf;
	public event Action<MonoBehaviour> onInteract;
	//List<IInteractable> interactables;
	List<MonoBehaviour> interactableMBs;
	//IInteractable currentTarget = null;
	MonoBehaviour currentTargetMB = null;

	[SerializeField] TMP_Text text;

	void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(this);

		interactableMBs = FindObjectsOfType<MonoBehaviour>()
			.Where(mb => mb is IInteractable).ToList();

		text.gameObject.SetActive(false);
	}

	void Update()
    {
		if (currentTargetMB != null)
			currentTargetMB = null;

		foreach (var mb in interactableMBs)
		{
			Vector3 interactablePosition = mb.GetComponent<IInteractable>().Position;
			//float distance = Vector3.Distance(playerCamTf.position, mb.transform.position);
			float distance = Vector3.Distance(playerCamTf.position, interactablePosition);
			//Vector3 playerCamToInteractable = (mb.transform.position - playerCamTf.transform.position).normalized;
			Vector3 playerCamToInteractable = (interactablePosition - playerCamTf.transform.position).normalized;
			float dot = Vector3.Dot(playerCamToInteractable, playerCamTf.forward);
			if (distance < 2.5f && dot > 0.98f)
				currentTargetMB = mb;
		}

		if (currentTargetMB != null)
		{
			if (!text.gameObject.activeSelf)
				text.gameObject.SetActive(true);

			if (Keyboard.current.eKey.wasPressedThisFrame)
				onInteract?.Invoke(currentTargetMB);
		}
		else
		{
			if (text.gameObject.activeSelf)
				text.gameObject.SetActive(false);
		}
	}
}
