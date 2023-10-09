
using UnityEngine;

public class RigidbodyExplosion : IExplosion
{
	public RigidbodyExplosion(Vector3 sourcePos, float power, float radius)
	{
		SourcePosition = sourcePos;
		Power = power > 0 ? power : 50f;
		Radius = radius > 0 ? radius : 10f;
	}

	public Vector3 SourcePosition { get; set; }
	public float Power { get; set; }
	public float Radius { get; set; }

	public void Explode()
	{
		var rbs = GameObject.FindObjectsOfType<Rigidbody>();
		foreach (var rb in rbs)
		{
			rb.AddExplosionForce(Power, SourcePosition, Radius);
		}
	}
}
