using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntBehaviour : MonoBehaviour
{
    public float GruntHealth = 5;

    void Start()
    {
    }

    void Update()
    {
        
    }


    public void TakeDamage(float Damage)
    {
        GruntHealth -= Damage;
        //RageTracker.RageTick();
        if (GruntHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
