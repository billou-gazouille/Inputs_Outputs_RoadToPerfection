
using UnityEngine;

public class ElevatorMB : OutputDeviceMB
{
	public Elevator elevator { get; private set; } = new Elevator();

	public override OutputDevice outputDevice => elevator;

	[SerializeField] float speed;
	[SerializeField] Transform startPosTf;
	[SerializeField] Transform endPosTf;

	public override void InitOutputDevice()
	{
		elevator.Init(startPosTf.position, endPosTf.position, speed);
	}

	void Update()
	{
		transform.position = elevator.CurrentPosition;
		elevator.UpdatePosition();
	}
}
