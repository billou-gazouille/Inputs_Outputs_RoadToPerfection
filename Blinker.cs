
using UnityEngine;

public class Blinker : MonoBehaviour
{
    [SerializeField] float delay;

    void Start()
    {
        var spotLight = GetComponent<Light>();
        var material = transform.parent.GetComponent<Renderer>().material;
        Timer.Loop(() =>
        {
            var color = new Color(Random.value, Random.value, Random.value);
            spotLight.color = color;
            var intensity = (color.r + color.g + color.b) / 3f;
            var factor = 10f / intensity;
            material.SetColor("_EmissionColor", color*factor);
        }, delay);
    }
}
