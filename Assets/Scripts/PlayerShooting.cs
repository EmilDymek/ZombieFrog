using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float FireRate = 0.0f;
    public float Damage = 1.0f;
    Vector3 MousePos;                                               //Variable to store mouse position
    Vector3 GunDirection;                                           //Variable to store gun direction

    void Start()
    {
        
    }


    void Update()
    {
        TurnGun();                                                  //Calls Turning function
    }

    void TurnGun()
    {
        MousePos = Input.mousePosition;                             //Updates the position variable
        MousePos = Camera.main.ScreenToWorldPoint(MousePos);        //Tracks the mouse position relative to the game window
        GunDirection = new Vector3(MousePos.x - transform.position.x, MousePos.y - transform.position.y);   //Updates the direction variable
        transform.right = GunDirection;                                                                     //Moves the gun in the direction of the stored variable (rotates towards the mouse)
    }
}
