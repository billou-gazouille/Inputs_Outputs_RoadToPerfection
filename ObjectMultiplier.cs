using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMultiplier : MonoBehaviour
{
    [SerializeField] [Range(2, 5)] int multiplier;
    [SerializeField] float delay;

    void Start()
    {
        Timer.WaitThenDo(delay, () =>
        {
            for (int i = 0; i < multiplier; i++)
            {
                Instantiate(gameObject);
            }
            Destroy(gameObject);
        });
    }
}
