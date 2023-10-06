
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseRaycaster : MonoBehaviour
{
	public static MouseRaycaster Instance { get; private set; } = null;

	[SerializeField] new Camera camera;

	public event Action<Ray, RaycastHit> onColliderHit;

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(this);

		if (camera ==  null)
			camera = Camera.main;
	}

	void Update()
	{
		if (Mouse.current.leftButton.wasPressedThisFrame)
		{
			Vector2 mousePos = Mouse.current.position.ReadValue();
			Vector3 pos3D = new Vector3(mousePos.x, mousePos.y, 0f);
			var ray = camera.ScreenPointToRay(pos3D);
			if (Physics.Raycast(ray, out RaycastHit hitInfo, 1000f))
			{
				//Debug.Log("hit " + hitInfo.collider.name);
				onColliderHit?.Invoke(ray, hitInfo);
			}
		}
	}
}
