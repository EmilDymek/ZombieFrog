using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    //Element0 is facing Down
    //Element1 is facing Up
    //Element2 is facing Right
    //Element3 is facing Left

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Going Right
        if(aiPath.desiredVelocity.x > 0.01 && aiPath.desiredVelocity.x > aiPath.desiredVelocity.y)
        {
            ChangeSprite(2);
        }
        //Going Left
        else if (aiPath.desiredVelocity.x < -0.01 && aiPath.desiredVelocity.x > aiPath.desiredVelocity.y)
        {
            ChangeSprite(3);
        }
        //Going Up
        else if (aiPath.desiredVelocity.y > 0.01 && aiPath.desiredVelocity.y > aiPath.desiredVelocity.x)
        {
            ChangeSprite(1);
        }
        //Going Down
        else if (aiPath.desiredVelocity.y < -0.01 && aiPath.desiredVelocity.y > aiPath.desiredVelocity.x)
        {
            ChangeSprite(0);
        }
    }

    void ChangeSprite(int spriteElement)
    {
        spriteRenderer.sprite = spriteArray[spriteElement];
    }
}
