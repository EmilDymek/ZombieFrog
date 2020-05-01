using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunQuake : MonoBehaviour
{
    private float QuakeTimer;
    private CircleCollider2D QuakeCollider;
    public GameMaster GM;
    public GameObject GMobj;

    void Awake()
    {
        GMobj = GameObject.Find("GM");
        GM = GMobj.GetComponent<GameMaster>();
        QuakeCollider = GetComponent<CircleCollider2D>();
        QuakeTimer = GM.QuakeDuration;
    }

    void Update()
    {
        QuakeCollider.radius += GM.QuakeGrowth * Time.deltaTime;
        QuakeTimer -= Time.deltaTime;

        if (QuakeTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
