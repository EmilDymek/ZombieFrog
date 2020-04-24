using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public EnemyHandler EH;
    public GameObject GM;
    public Rigidbody2D rb;
    public GameObject ImpactEffect;


    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GM");
        EH = GM.GetComponent<EnemyHandler>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * EH.GruntBulletSpeed;
    }

    void Update()
    {
        BulletUpdate();
    }

    private void OnTriggerEnter2D(Collider2D HitInfo)
    {
        if (HitInfo.tag == "Player")
        {
            if (HitInfo.tag == "Player")
            {
                GameMaster Player = GM.GetComponent<GameMaster>();
                Player.PlayerCurrentHealth -= EH.GruntDamage;
            }
            Instantiate(ImpactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void BulletUpdate()
    {
        EH.GruntBulletTimer -= Time.deltaTime;
        if (EH.GruntBulletTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
