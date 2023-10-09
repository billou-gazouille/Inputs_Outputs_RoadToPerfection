
using UnityEngine;

public class PillarMB : OutputDeviceMB
{
    Pillar pillar = new Pillar();

	public override OutputDevice outputDevice => pillar;

    void Update()
    {
        pillar.UpdateAngle();
        transform.rotation = Quaternion.Euler(pillar.Angle, 0f, 0f);
	}
}
