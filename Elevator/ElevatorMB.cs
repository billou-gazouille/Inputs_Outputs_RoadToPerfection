
using UnityEngine;

public class ElevatorMB : OutputDeviceMB
{
	public Elevator elevator { get; private set; }

	public override OutputDevice outDev => elevator;

	[SerializeField] float speed;
	[SerializeField] Transform startPosTf;
	[SerializeField] Transform endPosTf;

	//void Start()
	void Awake()
	{
		elevator = new Elevator(startPosTf.position, endPosTf.position, speed);
	}

	void Update()
	{
		transform.position = elevator.CurrentPosition;
		elevator.UpdatePosition();
	}
}
