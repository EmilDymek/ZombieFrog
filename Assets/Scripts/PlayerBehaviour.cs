﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public GameMaster GM;
    public GameObject GMobj;

    private Vector2 PlayerDirection;                                             //Variable for PlayerDirection
    public Vector3 PlayerPosition;                                               //Variable for Player position
    private Rigidbody2D PlayerBody;                                              //Keeps a reference to rigidbody
    bool PlayerDashing = false;
    bool PlayerStunning = false;
    public GameObject Stun;
    
    void Awake()                                                                 //This is the Start function
    {
        GMobj = GameObject.Find("GM");
        GM = GMobj.GetComponent<GameMaster>();
        PlayerBody = GetComponent<Rigidbody2D>();                                //Initializes the rigidbody
    }


    void Update()                                                               //This is the update function
    {
        GetInput();                                                             //Calls the GetInput Function
        PlayerPosition = this.transform.position;

        //Dashtimer
        if (GM.PlayerDashTimer >= 0)
        {
            GM.PlayerDashTimer -= Time.deltaTime;
        }
        //Stuntimer
        if (GM.StunTimer >= 0)
        {
            GM.StunTimer -= Time.deltaTime;
        }
    }


    void GetInput()                                                             //This function checks for player input and moves the direction of movement accordingly
    {
        //Player movement
        PlayerDirection = Vector2.zero;                                         //Zeroes the cameras direction
        if (Input.GetKey(KeyCode.W))                                            //Checks if W is being pressed
        {
            PlayerDirection += Vector2.up;                                      //Sets direction to up if W is being pressed
        }
        if (Input.GetKey(KeyCode.A))                                            //Checks if A is being pressed
        {
            PlayerDirection += Vector2.left;                                    //Sets direction to left if A is being pressed
        }
        if (Input.GetKey(KeyCode.S))                                            //Checks if S is being pressed
        {
            PlayerDirection += Vector2.down;                                    //Sets direction to down if S is being pressed
        }
        if (Input.GetKey(KeyCode.D))                                            //Checks if D is being pressed
        {
            PlayerDirection += Vector2.right;                                   //Sets direction to right if D is being pressed
        }

        //Player abilities
        if (Input.GetKey(KeyCode.LeftShift) && PlayerDirection != Vector2.zero)
        {
            PlayerDashing = true;
        } else
        {
            PlayerDashing = false;
        }
        transform.Translate(PlayerDirection * GM.PlayerMoveSpeed * Time.deltaTime);    //Moves the player according to the set direction

        if (Input.GetKey(KeyCode.F))
        {
            PlayerStunning = true;
        } else
        {
            PlayerStunning = false;
        }
        
        if (Input.GetKey(KeyCode.Mouse1))
        {
            PlayerMelee();
        }

        if (PlayerDashing && GM.PlayerDashTimer <= 0 && GM.PlayerCurrentRage >= GM.DashRageCost)
        {
            //PlayerDash();
            GM.PlayerDashTimer = GM.PlayerDashCooldown;
            GM.PlayerCurrentRage -= GM.DashRageCost;
        }
        if (PlayerStunning && GM.StunTimer <= 0 && GM.PlayerCurrentRage >= GM.StunRageCost)
        {
            PlayerStun();
            GM.StunTimer = GM.StunCooldown;
            GM.PlayerCurrentRage -= GM.StunRageCost;
        }

        //Player shooting found in Player Shooting script
    }

    //public void PlayerDash()
    //{
    //    transform.Translate(PlayerDirection * GM.PlayerDashDistance * Time.deltaTime);
    //}
    public void PlayerStun()
    {
        Instantiate(Stun);
    }
    public void PlayerMelee()
    {
        Debug.Log("Player Melee Logic not added yet");
    }
}
