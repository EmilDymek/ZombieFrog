using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGFX : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    //Element 0 is Right
    //Element 1 is Left
    //Element 2 is Down
    //Element 3 is Up

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            spriteRenderer.sprite = spriteArray[3];
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            spriteRenderer.sprite = spriteArray[2];
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            spriteRenderer.sprite = spriteArray[1];
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.sprite = spriteArray[0];
        }
    }
}
