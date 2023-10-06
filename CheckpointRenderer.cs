using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointRenderer : MonoBehaviour
{
    [SerializeField] List<Renderer> renderers;

    public void SetMaterial(Material material)
    {
        foreach (var renderer in renderers)
        {
            renderer.material = material;
        }
    }
}
