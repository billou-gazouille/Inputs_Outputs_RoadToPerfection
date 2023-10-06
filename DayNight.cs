using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    float x = 0f;

    void Update()
    {
        transform.rotation = Quaternion.Euler(x, 0f, 0f);
        x += 0.1f;
    }
}
