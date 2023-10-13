
using System;
using UnityEngine;

public interface IInteractable
{
    void Interact();

    Vector3 Position { get; }
}
