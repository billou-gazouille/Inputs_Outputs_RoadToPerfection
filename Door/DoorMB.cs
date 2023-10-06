
using UnityEngine;

public class DoorMB : OutputDeviceMB
{
	public Door door { get; private set; }

	void Start()
	{
		outputDevice = new Door();
		door = (Door)outputDevice;
		door.SetClosedRotation(transform.rotation);
		door.onChangeState += (newRotation) => transform.rotation = newRotation;
	}

	/*
	void Awake()
	{
		base.Awake();
		initRotation = transform.rotation;
	}
	*/
}
