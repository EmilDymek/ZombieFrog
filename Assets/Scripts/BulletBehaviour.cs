using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float BulletSpeed = 200.0f;
    public float BulletTimer = 1.0f;
    public float BulletDamage = 1.0f;
    public Rigidbody2D rb;
    public GameObject ImpactEffect;

    void Start()
    {
        rb.velocity = transform.right * BulletSpeed;
    }

    void Update()
    {
        BulletUpdate();
    }

    private void OnTriggerEnter2D(Collider2D HitInfo)
    {
        if (HitInfo.tag != "Player" && HitInfo.tag != "Bullet")
        {
            GruntBehaviour Enemy = HitInfo.GetComponent<GruntBehaviour>();
            if (Enemy)
            {
                Enemy.TakeDamage(BulletDamage);
            }
            Instantiate(ImpactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void BulletUpdate()
    {
        BulletTimer -= Time.deltaTime;
        if (BulletTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
