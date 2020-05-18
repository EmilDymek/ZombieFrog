using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

namespace Pathfinding
{
    [UniqueComponent(tag = "ai.destination")]



    public class AstarEnemyBehaviour : VersionedMonoBehaviour
    {
        public Transform target;
        IAstarAI ai;

        public AIPath aiPath;
        public GameMaster GM;
        public EnemyHandler EH;
        public GameObject GMobj;

        private float FireTimer;
        private bool IsStunned = false;
        private float StunTimer;

        public Transform Player;
        public Transform Firepoint;
        public Transform Gun;
        public GameObject Bullet;
        public RageTracker rageTracker;

        void Awake()
        {
            GMobj = GameObject.Find("GM");
            GM = GMobj.GetComponent<GameMaster>();
            EH = GMobj.GetComponent<EnemyHandler>();
            rageTracker = GM.GetComponent<RageTracker>();
            Player = GameObject.FindGameObjectWithTag("Player").transform;
            FireTimer = EH.GruntFireRate;
        }


        void Update()
        {
            if (target != null && ai != null) ai.destination = target.position;

            if (IsStunned == false)
            {
                //Movement behaviour
                //if (Vector2.Distance(transform.position, Player.position) > EH.GruntStopDistance)
                //{
                //    EnemyBody.velocity = Vector2.MoveTowards(transform.position, Player.position, Time.deltaTime * EH.GruntSpeed);
                //}
                //else if (Vector2.Distance(transform.position, Player.position) < EH.GruntRetreatDistance)
                //{
                //    EnemyBody.velocity = Vector2.MoveTowards(transform.position, Player.position, Time.deltaTime * -EH.GruntSpeed);
                //}

                //Shooting Behaviour
                if (FireTimer <= 0)
                {
                    Instantiate(Bullet, Firepoint.position, Firepoint.rotation);
                    FireTimer = EH.GruntFireRate;
                }
                else
                {
                    FireTimer -= Time.deltaTime;
                }

                Vector3 Target = Player.position; Vector3 GunPos = Gun.position;
                Target.x = Target.x - GunPos.x;
                Target.y = Target.y - GunPos.y;

                float angle = Mathf.Atan2(Target.y, Target.x) * Mathf.Rad2Deg;
                Gun.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
            else
            {
                StunTimer -= Time.deltaTime;
                if (StunTimer <= 0)
                {
                    IsStunned = false;
                }
            }
        }

        void OnEnable()
        {
            ai = GetComponent<IAstarAI>();
            // Update the destination right before searching for a path as well.
            // This is enough in theory, but this script will also update the destination every
            // frame as the destination is used for debugging and may be used for other things by other
            // scripts as well. So it makes sense that it is up to date every frame.
            if (ai != null) ai.onSearchPath += Update;
        }
        void OnDisable()
        {
            if (ai != null) ai.onSearchPath -= Update;
        }

        public void Die()
        {
            Destroy(gameObject);
        }

        public void Stunned()
        {
            IsStunned = true;
            StunTimer = GM.QuakeDuration;
        }
    }
}
