using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthManager : MonoBehaviour
{
    //SpriteRenderer tempRend;
    //public bool IsPlayer;
    //float timer = 1;
    [SerializeField]
    int sortingOrderBase = 5000;
    [SerializeField]
    int offset = 0;
    Renderer tempRend;
    [SerializeField]
    private bool runOnce = true;

    void Awake()
    {
        tempRend = gameObject.GetComponent<Renderer>();
        //tempRend = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        tempRend.sortingOrder = (int)(sortingOrderBase - transform.position.y - offset);
        if (runOnce)
        {
            Destroy(this);
        }
    }

//    void Update()
//    {

//        tempRend.sortingOrder = (int)Camera.main.ScreenToWorldPoint(this.transform.position).y * -1;

//        timer -= Time.deltaTime;
//        if (timer <= 0)
//        {
//            tempRend.color = new Color(1, 1, 1, 1);
//            timer = 1;
//        }
//    }

//    void OnTriggerEnter2D(Collider2D other)
//    {
//        if (IsPlayer == false && other.GetComponent<DepthManager>().IsPlayer == true)
//        {
//            tempRend.color = new Color(1, 1, 1, .5f);
//            timer = 1;
//        }
//    }
}
