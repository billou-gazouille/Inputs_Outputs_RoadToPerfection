
using UnityEngine;

public class ExplosionDevice : OutputDevice
{
	public ExplosionDevice(IExplosion explosion) => Explosion = explosion;

	public IExplosion Explosion { get; }

	protected override void Activate() => Explosion.Explode();

	protected override void BehaviourIfNullInput() { }	 // do nothing if null input
}
