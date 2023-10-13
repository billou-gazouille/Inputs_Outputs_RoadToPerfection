
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonPush : MonoBehaviour
{
    [SerializeField] TimerButtonMB timerButtonMB;
    TimerButton timerButton;
    [SerializeField] Transform buttonTf;
    [SerializeField] Transform buttonPushedTf;
    [SerializeField] Transform buttonReleasedTf;

	[SerializeField] Collider buttonCollider;


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


		MouseRaycaster.Instance.onColliderHit += (Ray ray, RaycastHit hitInfo) =>
		{
			if (hitInfo.collider == buttonCollider)
			{
				//Debug.Log($"Clicked on button: {name}");
				timerButton.Press();
			}
		};
	}
}
