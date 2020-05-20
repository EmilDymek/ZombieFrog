using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntBehaviour : MonoBehaviour
{
    public GameMaster GM;
    public EnemyHandler EH;
    public GameObject GMobj;

    private float ThisGruntHealth;
    private float FireTimer;
    private bool IsStunned = false;
    private float StunTimer;
    private Rigidbody2D EnemyBody;

    public Transform Player;
    public Transform Firepoint;
    public Transform Gun;
    public GameObject Bullet;
    public RageTracker rageTracker;
    public GameObject[] OtherEnemies;

    void Awake()
    {
        GMobj = GameObject.Find("GM");
        GM = GMobj.GetComponent<GameMaster>();
        EH = GMobj.GetComponent<EnemyHandler>();
        rageTracker = GM.GetComponent<RageTracker>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        EnemyBody = GetComponent<Rigidbody2D>();
        FireTimer = EH.GruntFireRate;
        ThisGruntHealth = EH.GruntHealth;
    }

    void Update()
    {
        if (IsStunned == false)
        {
            //Movement behaviour
            if (Vector2.Distance(transform.position, Player.position) > EH.GruntStopDistance)
            {
                EnemyBody.velocity = Vector2.MoveTowards(transform.position, Player.position, Time.deltaTime * EH.GruntSpeed);
                //transform.position = Vector2.MoveTowards(transform.position, Player.position, Time.deltaTime * EH.GruntSpeed);
            } else if (Vector2.Distance(transform.position, Player.position) < EH.GruntRetreatDistance)
            {
                EnemyBody.velocity = Vector2.MoveTowards(transform.position, Player.position, Time.deltaTime * -EH.GruntSpeed);
                //transform.position = Vector2.MoveTowards(transform.position, Player.position, Time.deltaTime * -EH.GruntSpeed);
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
        } else
        {
            StunTimer -= Time.deltaTime;
            if (StunTimer <= 0)
            {
                IsStunned = false;
            }
        }
    }

    

    public void TakeDamage(float Damage)
    {
        ThisGruntHealth -= Damage;
        
        rageTracker.RageTick();
        if (ThisGruntHealth <= 0)
        {
            Die();
        }
    }

    public void TakeStun()
    {
        IsStunned = true;
        StunTimer = GM.QuakeDuration;
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
