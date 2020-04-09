using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactEffectBehaviour : MonoBehaviour
{
    float EffectLife = 1.0f;

    void Update()
    {
        EffectLife -= Time.deltaTime;
        if (EffectLife <= 0)
        {
            Destroy(gameObject);
        }
    }
}
