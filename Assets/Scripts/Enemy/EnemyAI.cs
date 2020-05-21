using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public GameMaster GM;
    public EnemyHandler EH;
    public GameObject GMobj;

    public GameObject bullet;
    public Transform firePoint;
    public Transform target;
    public float nextWaypointDistance = 2;
    public RageTracker rageTracker;

    Vector2 enemyDirection;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    
    Seeker seeker;
    Rigidbody2D rb;

    bool engaged = false;
    bool stunned = false;
    float stunTimer = 0;
    float fireTimer = 0;
    float health;

    //Temp Variables, move to GM later
    public float engageDistance;
    public float stopDistance;
    public float retreatDistance;
    public float stunDuration = 5;
    public float fireRate = 0.3f;

    void Start()
    {
        GMobj = GameObject.Find("GM");
        EH = GMobj.GetComponent<EnemyHandler>();
        GM = GMobj.GetComponent<GameMaster>();

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        health = EH.gruntHealth;

        InvokeRepeating("UpdatePath", 0f, .5f);
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }


    void FixedUpdate()
    {
        if (!stunned)
        {
            if (Vector2.Distance(transform.position, target.position) < engageDistance)
                engaged = true;

            if (Vector2.Distance(transform.position, target.position) > stopDistance && engaged)
            {
                ChasePlayer();
            } else if (Vector2.Distance(transform.position, target.position) < retreatDistance)
            {
                Retreat();
            } else if (engaged)
            {
                Shoot();
            }
        } else
        {
            stunTimer -= Time.deltaTime;
            if (stunTimer <= 0)
            {
                stunned = false;
            }
        }

        if (fireTimer > 0)
        {
            fireTimer -= Time.deltaTime;
        }
    }

    public void Stun()
    {
        stunned = true;
        stunTimer = stunDuration;
    } 

    public void Damage(float Damage)
    {
        health -= Damage;
        rageTracker.RageTick();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        Vector3 aimPos = target.position; Vector3 gunPos = firePoint.position;
        aimPos.x = aimPos.x - gunPos.x;
        aimPos.y = aimPos.y - gunPos.y;

        float angle = Mathf.Atan2(aimPos.y, aimPos.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (fireTimer <= 0)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            fireTimer = fireRate;
        }
    }

    void Retreat()
    {
        //rb.velocity = new Vector2(transform.position, target.position) * -EH.GruntSpeed * Time.deltaTime;
        //rb.velocity = Vector2(transform.position, target.position, Time.deltaTime * -EH.GruntSpeed / 5);

        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        GetDirection();

        rb.velocity = enemyDirection * -EH.gruntSpeed * Time.deltaTime;

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }

    void ChasePlayer()
    {
        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        GetDirection();

        rb.velocity = enemyDirection * EH.gruntSpeed * Time.deltaTime;

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }

    void GetDirection()
    {
        enemyDirection = Vector2.zero;
        enemyDirection = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
    }

    void OnPathComplete(Path newPath)
    {
        if (!newPath.error)
        {
            path = newPath;
            currentWaypoint = 0;
        }
    }
}
