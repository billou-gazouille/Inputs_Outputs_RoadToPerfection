
using UnityEngine;

public class ExplosionDeviceMB : OutputDeviceMB
{
	[SerializeField] float power;
	[SerializeField] float radius;

	ExplosionDevice explosionDevice = new ExplosionDevice();
	public override OutputDevice outputDevice => explosionDevice;

	public override void InitOutputDevice()
	{
		IExplosion explosion = new RigidbodyExplosion(transform.position, power, radius);
		explosionDevice.Init(explosion);
	}
}
