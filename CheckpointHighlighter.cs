using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHighlighter : MonoBehaviour
{
    [SerializeField] Material unhighlightMaterial;
    [SerializeField] Material highlightMaterial;

    private void Awake()
    {
        Checkpoint.onEntered += (Checkpoint checkpoint) =>
        {
            Unhighlight(checkpoint);
            if (checkpoint.nextCheckpoint != null)
                Highlight(checkpoint.nextCheckpoint);
        };
    }

    void Highlight(Checkpoint newCheckpoint)
    {
        newCheckpoint.GetComponent<CheckpointRenderer>().SetMaterial(highlightMaterial);
    }

    void Unhighlight(Checkpoint prevCheckpoint)
    {
        prevCheckpoint.GetComponent<CheckpointRenderer>().SetMaterial(unhighlightMaterial);
    }
}
