
using UnityEngine;

public class ExplosionDevice : OutputDevice
{

	public IExplosion Explosion { get; private set; }

	protected override void Activate() => Explosion.Explode();

	protected override void BehaviourIfNullInput() { }	 // do nothing if null input
	public void Init(IExplosion explosion) => Explosion = explosion;
}
