using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
    public class AstarEnemyHitbox : MonoBehaviour
    {
        public GameMaster GM;
        public EnemyHandler EH;
        public GameObject GMobj;
        public AstarEnemyBehaviour EB;

        public RageTracker rageTracker;

        private float ThisGruntHealth;
        private Rigidbody2D EnemyBody;


        void Awake()
        {
            GMobj = GameObject.Find("GM");
            GM = GMobj.GetComponent<GameMaster>();
            EH = GMobj.GetComponent<EnemyHandler>();
            EB.GetComponent<AstarEnemyBehaviour>();
            rageTracker = GM.GetComponent<RageTracker>();
            EnemyBody = GetComponent<Rigidbody2D>();
            ThisGruntHealth = EH.gruntHealth;
        }

        public void TakeDamage(float Damage)
        {
            ThisGruntHealth -= Damage;

            rageTracker.RageTick();
            if (ThisGruntHealth <= 0)
            {
                EB.Die();
            }
        }

        public void TakeStun()
        {
            EB.Stunned();
        }
    }
}
