
using UnityEngine;

[RequireComponent(typeof(SquareWaveInputMB))]
[RequireComponent(typeof(Renderer))]

public class SquareWaveLightUp : MonoBehaviour
{
    SquareWaveInput squareWaveInput;
    Renderer rend;

    void Start()
    {
		squareWaveInput = GetComponent<SquareWaveInputMB>().squareWaveInput;
		rend = GetComponent<Renderer>();

        squareWaveInput.onTriggered += LightOn;
        squareWaveInput.onUntriggered += LightOff;

        LightOff();
	}

    void LightOn() => rend.material.EnableKeyword("_EMISSION");
    void LightOff() => rend.material.DisableKeyword("_EMISSION");
}
