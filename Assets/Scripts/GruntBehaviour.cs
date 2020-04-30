using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntBehaviour : MonoBehaviour
{
    public float GruntHealth;
    private float FireTimer;

    public Transform Player;
    public Transform Firepoint;
    public Transform Gun;
    public GameObject Bullet;
    public GameObject GM;
    public RageTracker rageTracker;
    public EnemyHandler EH;
    public GameObject[] OtherEnemies;

    void Awake()
    {
        GM = GameObject.FindGameObjectWithTag("GM");
        EH = GM.GetComponent<EnemyHandler>();
        rageTracker = GM.GetComponent<RageTracker>();
        //GameMaster.GetComponent<GameMaster>();
        //EH.GetComponent<EnemyHandler>();
        //rageTracker.GetComponent<RageTracker>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        FireTimer = EH.GruntFireRate;
    }

    void Update()
    {
        //Movement behaviour
        OtherEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        //if (Vector2.Distance(transform.position, OtherEnemies))
        //{

        //}
        if (Vector2.Distance(transform.position, Player.position) > EH.GruntStopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, Time.deltaTime * EH.GruntSpeed);
        } else if(Vector2.Distance(transform.position, Player.position) < EH.GruntRetreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, Time.deltaTime * -EH.GruntSpeed);
        }

        //Shooting Behaviour
        if (FireTimer <= 0)
        {
            Instantiate(Bullet, Firepoint.position, Firepoint.rotation);
            FireTimer = EH.GruntFireRate;
        } else 
        {
            FireTimer -= Time.deltaTime;
        }

        Vector3 Target = Player.position; Vector3 GunPos = Gun.position;
        Target.x = Target.x - GunPos.x;
        Target.y = Target.y - GunPos.y;

        float angle = Mathf.Atan2(Target.y, Target.x) * Mathf.Rad2Deg;
        Gun.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    

    public void TakeDamage(float Damage)
    {
        GruntHealth -= Damage;
        
        rageTracker.RageTick();
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
