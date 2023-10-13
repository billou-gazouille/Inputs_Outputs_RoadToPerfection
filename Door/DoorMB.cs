
using UnityEngine;

public class DoorMB : OutputDeviceMB
{
	public Door door { get; private set; } = new Door();

	public override OutputDevice outputDevice => door;

	//void Start()
	void Awake()
	{
		door.SetClosedRotation(transform.rotation);
		door.onChangeState += (newRotation) => transform.rotation = newRotation;
	}
	
	//void Update() => Debug.Log(door.IsActive);
}
