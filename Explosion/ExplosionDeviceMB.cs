
using UnityEngine;

public class ExplosionDeviceMB : OutputDeviceMB
{
	[SerializeField] float power;
	[SerializeField] float radius;

	ExplosionDevice explosionDevice;
	public override OutputDevice outputDevice => explosionDevice;

	void Awake()
	{
		IExplosion explosion = new RigidbodyExplosion(transform.position, power, radius);
		explosionDevice = new ExplosionDevice(explosion);
	}
}
