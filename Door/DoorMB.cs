
using UnityEngine;

public class DoorMB : OutputDeviceMB
{
	public Door door { get; private set; } = new Door();

	public override OutputDevice outputDevice => door;

	[SerializeField] Transform pivotTf;

	public override void InitOutputDevice()
	{
		door.SetClosedRotation(transform.rotation);
		door.onChangeState += (newRotation) => pivotTf.rotation = newRotation;
	}

	//void Update() => Debug.Log(door.IsActive);
}
