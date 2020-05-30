using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGFX : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject[] animArray;
    public Sprite[] spriteArray;
    private float angle;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    spriteRenderer.sprite = spriteArray[0];
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    spriteRenderer.sprite = spriteArray[1];
        //}
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    spriteRenderer.sprite = spriteArray[2];
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    spriteRenderer.sprite = spriteArray[3];
        //}
        FindMouseAngle();
        UpdateSprite();
    }

    void UpdateSprite()
    {
        if (angle < 135 && angle > 45)
        {
            //LEFT
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S))
            {
                PlayAnimLeft();
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
            {
                PlayAnimLeftR();
            }
            else
            {
                spriteRenderer.sprite = spriteArray[2];
                animArray[0].SetActive(false);
                animArray[1].SetActive(false);
                animArray[2].SetActive(false);
                animArray[3].SetActive(false);
                animArray[4].SetActive(false);
                animArray[5].SetActive(false);
                animArray[6].SetActive(false);
                animArray[7].SetActive(false);
            }
        }
        else if (angle < -45 && angle > -135)
        {
            //RIGHT
            if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
            {
                PlayAnimRight();
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W))
            {
                PlayAnimRightR();
            }
            else
            {
                spriteRenderer.sprite = spriteArray[3];
                animArray[0].SetActive(false);
                animArray[1].SetActive(false);
                animArray[2].SetActive(false);
                animArray[3].SetActive(false);
                animArray[4].SetActive(false);
                animArray[5].SetActive(false);
                animArray[6].SetActive(false);
                animArray[7].SetActive(false);
            }
        }
        else if (angle < 45 && angle > -45)
        {
            //DOWN
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S))
            {
                PlayAnimDown();
            }
            else if (Input.GetKey(KeyCode.W))
            {
                PlayAnimDownR();
            }
            else
            {
                spriteRenderer.sprite = spriteArray[1];
                animArray[0].SetActive(false);
                animArray[1].SetActive(false);
                animArray[2].SetActive(false);
                animArray[3].SetActive(false);
                animArray[4].SetActive(false);
                animArray[5].SetActive(false);
                animArray[6].SetActive(false);
                animArray[7].SetActive(false);
            }
        }
        else if (angle > 135 || angle < -135)
        {
            //UP
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                PlayAnimUp();
            }
            else if (Input.GetKey(KeyCode.A))
            {
                PlayAnimUpR();
            }
            else
            {
                spriteRenderer.sprite = spriteArray[0];
                animArray[0].SetActive(false);
                animArray[1].SetActive(false);
                animArray[2].SetActive(false);
                animArray[3].SetActive(false);
                animArray[4].SetActive(false);
                animArray[5].SetActive(false);
                animArray[6].SetActive(false);
                animArray[7].SetActive(false);
            }
        }
    }

    //This really isn't the best way of doing this but I honestly cannot be fucked to research a proper implementation at this point
    void PlayAnimUp()
    {
        spriteRenderer.sprite = spriteArray[4];
        animArray[0].SetActive(true);
        animArray[1].SetActive(false);
        animArray[2].SetActive(false);
        animArray[3].SetActive(false);
        animArray[4].SetActive(false);
        animArray[5].SetActive(false);
        animArray[6].SetActive(false);
        animArray[7].SetActive(false);
    }

    void PlayAnimDown()
    {
        spriteRenderer.sprite = spriteArray[4];
        animArray[0].SetActive(false);
        animArray[1].SetActive(true);
        animArray[2].SetActive(false);
        animArray[3].SetActive(false);
        animArray[4].SetActive(false);
        animArray[5].SetActive(false);
        animArray[6].SetActive(false);
        animArray[7].SetActive(false);
    }

    void PlayAnimLeft()
    {
        spriteRenderer.sprite = spriteArray[4];
        animArray[0].SetActive(false);
        animArray[1].SetActive(false);
        animArray[2].SetActive(true);
        animArray[3].SetActive(false);
        animArray[4].SetActive(false);
        animArray[5].SetActive(false);
        animArray[6].SetActive(false);
        animArray[7].SetActive(false);
    }

    void PlayAnimRight()
    {
        spriteRenderer.sprite = spriteArray[4];
        animArray[0].SetActive(false);
        animArray[1].SetActive(false);
        animArray[2].SetActive(false);
        animArray[3].SetActive(true);
        animArray[4].SetActive(false);
        animArray[5].SetActive(false);
        animArray[6].SetActive(false);
        animArray[7].SetActive(false);
    }

    void PlayAnimUpR()
    {
        animArray[0].SetActive(false);
        animArray[1].SetActive(false);
        animArray[2].SetActive(false);
        animArray[3].SetActive(false);
        animArray[4].SetActive(true);
        animArray[5].SetActive(false);
        animArray[6].SetActive(false);
        animArray[7].SetActive(false);
    }

    void PlayAnimDownR()
    {
        animArray[0].SetActive(false);
        animArray[1].SetActive(false);
        animArray[2].SetActive(false);
        animArray[3].SetActive(false);
        animArray[4].SetActive(false);
        animArray[5].SetActive(true);
        animArray[6].SetActive(false);
        animArray[7].SetActive(false);
    }

    void PlayAnimLeftR()
    {
        animArray[0].SetActive(false);
        animArray[1].SetActive(false);
        animArray[2].SetActive(false);
        animArray[3].SetActive(false);
        animArray[4].SetActive(false);
        animArray[5].SetActive(false);
        animArray[6].SetActive(true);
        animArray[7].SetActive(false);
    }

    void PlayAnimRightR()
    {
        animArray[0].SetActive(false);
        animArray[1].SetActive(false);
        animArray[2].SetActive(false);
        animArray[3].SetActive(false);
        animArray[4].SetActive(false);
        animArray[5].SetActive(false);
        animArray[6].SetActive(false);
        animArray[7].SetActive(true);
    }

    void FindMouseAngle()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //Vector2 direction = new Vector2(
        //    mousePosition.x - transform.position.x,
        //    mousePosition.y - transform.position.y 
        //    );
        //transform.up = direction;

        angle = Mathf.Atan2(
            transform.position.x - mousePosition.x,
            transform.position.y - mousePosition.y
            ) * Mathf.Rad2Deg;
        //Debug.Log(angle);
    }
}
