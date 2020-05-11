using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunQuake : MonoBehaviour
{
    public GameMaster GM;
    public GameObject GMobj;

    private float QuakeTimer;
    private CircleCollider2D QuakeCollider;

    void Awake()
    {
        GMobj = GameObject.Find("GM");
        GM = GMobj.GetComponent<GameMaster>();
        QuakeCollider = GetComponent<CircleCollider2D>();
        QuakeTimer = GM.QuakeDuration;
    }

    void Update()
    {
        transform.localScale += Vector3.one * GM.QuakeGrowth * Time.deltaTime;
        QuakeTimer -= Time.deltaTime;

        if (QuakeTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D HitInfo)
    {
        if (HitInfo.tag == "Enemy")
        {
            GruntBehaviour Enemy = HitInfo.GetComponent<GruntBehaviour>();
            Enemy.TakeStun();
        }
    }
}
