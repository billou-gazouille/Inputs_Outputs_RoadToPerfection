using UnityEngine;

public interface IExplosion
{
	Vector3 SourcePosition { get; set; }
	float Power { get; set; }
	float Radius { get; set; }

	void Explode();
}
