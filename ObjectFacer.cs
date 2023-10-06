using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFacer : MonoBehaviour
{
    [SerializeField] Transform objectToFace;

    void LateUpdate()
    {
        transform.LookAt(objectToFace);
    }
}
