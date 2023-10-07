
using UnityEngine;

public class ElevatorMB : OutputDeviceMB
{
	public Elevator elevator { get; private set; }

	[SerializeField] float speed;
	[SerializeField] Transform startPosTf;
	[SerializeField] Transform endPosTf;

	void Start()
	{
		outputDevice = new Elevator(startPosTf.position, endPosTf.position, speed);
		elevator = (Elevator)outputDevice;
	}

	void Update()
	{
		transform.position = elevator.CurrentPosition;
		elevator.UpdatePosition();
	}
}
