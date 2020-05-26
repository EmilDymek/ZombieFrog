using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthManager : MonoBehaviour
{
    SpriteRenderer tempRend;
    public bool IsPlayer;
    float timer = 1;

    void Awake()
    {
        tempRend = GetComponent<SpriteRenderer>();
    }


    void Update()
    {

        tempRend.sortingOrder = (int)Camera.main.ScreenToWorldPoint(this.transform.position).y * -1;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            tempRend.color = new Color(1, 1, 1, 1);
            timer = 1;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (IsPlayer == false && other.GetComponent<DepthManager>().IsPlayer == true)
        {
            tempRend.color = new Color(1, 1, 1, .5f);
            timer = 1;
        }
    }
}
