﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float BulletSpeed = 20.0f;
    public Rigidbody2D rb;
    public float BulletTimer = 1.0f;

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
        if (HitInfo.tag != "Player")
        {
            Debug.Log(HitInfo.name);
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
