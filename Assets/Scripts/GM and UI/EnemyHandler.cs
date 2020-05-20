using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    public GameMaster GM;
    public GameObject GMobj;
    public bool EnemySpawn;

    public GameObject GruntEnemy;
    //Grunt Variables
    public float GruntSpeed;
    public float GruntStopDistance;
    public float GruntFormationDistance;
    public float GruntRetreatDistance;
    public float GruntFireRate;
    public float GruntDamage;
    public float GruntBulletSpeed;
    public float GruntBulletTimer;
    public float GruntHealth;

    public float TimeToSpawn = 5;
    public float SpawnTimer = 0;

    private void Awake()
    {
        GMobj = GameObject.Find("GM");
        GM = GMobj.GetComponent<GameMaster>();
    }
    private void Update()
    {
        if (EnemySpawn)
        {
            SpawnTimer -= Time.deltaTime;
            if (SpawnTimer <= 0)
            {
                Instantiate(GruntEnemy);
                SpawnTimer = TimeToSpawn;
            }
        }
    }
}
