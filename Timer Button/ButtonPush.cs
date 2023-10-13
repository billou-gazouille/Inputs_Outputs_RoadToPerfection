
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonPush : MonoBehaviour, IInteractable
{
    [SerializeField] TimerButtonMB timerButtonMB;
    TimerButton timerButton;
    [SerializeField] Transform buttonTf;
    [SerializeField] Transform buttonPushedTf;
    [SerializeField] Transform buttonReleasedTf;

	[SerializeField] Collider buttonCollider;

	public void Interact() => timerButton.Press();
	public Vector3 Position => buttonTf.position;


	private void Start()
	{
		buttonTf.position = buttonReleasedTf.position;

		timerButton = timerButtonMB.timerButton;

		timerButton.onTriggered += () =>
		{
			//Debug.Log("Pressed button");
			buttonTf.position = buttonPushedTf.position;
			AudioManager.Instance?.Play3DSound("ButtonPress", buttonTf.position);
		};

		timerButton.onUntriggered += () =>
		{
			buttonTf.position = buttonReleasedTf.position;
			AudioManager.Instance?.Play3DSound("ButtonRelease", buttonTf.position);
		};


		/*
		MouseRaycaster.Instance.onColliderHit += (Ray ray, RaycastHit hitInfo) =>
		{
			if (hitInfo.collider == buttonCollider)
			{
				//Debug.Log($"Clicked on button: {name}");
				timerButton.Press();
			}
		};
		*/

		PlayerInteraction.Instance.onInteract += (MonoBehaviour mb) =>
		{
			//Debug.Log("TimerButton interact!", this);
			//Debug.Log($"{this} ; {mb}");
			if (this != mb)
				return;
			//Debug.Log("Sweet!", this);
			//timerButton.Press();
			Interact();
		};
	}
}
