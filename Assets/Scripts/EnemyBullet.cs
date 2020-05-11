using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameMaster GM;
    public EnemyHandler EH;
    public GameObject GMobj;

    public Rigidbody2D rb;
    public GameObject ImpactEffect;
    private float BulletTimer;


    void Start()
    {
        GMobj = GameObject.Find("GM");
        GM = GMobj.GetComponent<GameMaster>();
        EH = GMobj.GetComponent<EnemyHandler>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * EH.GruntBulletSpeed;
        BulletTimer = EH.GruntBulletTimer;
    }

    void Update()
    {
        BulletUpdate();
        BulletTimer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D HitInfo)
    {
        if (HitInfo.tag != "Enemy")
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
        if (BulletTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
