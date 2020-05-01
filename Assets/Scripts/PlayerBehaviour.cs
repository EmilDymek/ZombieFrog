using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Vector2 PlayerDirection;                                             //Variable for PlayerDirection
    public Vector3 PlayerPosition;                                               //Variable for Player position
    private Rigidbody2D PlayerBody;                                              //Keeps a reference to rigidbody
    public GameMaster GM;
    bool PlayerDashing = false;
    bool PlayerStunning = false;
    public GameObject Stun;

    void Start()                                                                 //This is the Start function
    {
        PlayerBody = GetComponent<Rigidbody2D>();                                //Initializes the rigidbody
    }


    void Update()                                                               //This is the update function
    {
        GetInput();                                                             //Calls the GetInput Function
        PlayerPosition = this.transform.position;
        if (GM.PlayerDashTimer >= 0)
        {
            GM.PlayerDashTimer -= Time.deltaTime;
        }
    }


    void GetInput()                                                             //This function checks for player input and moves the direction of movement accordingly
    {
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

        if (Input.GetKey(KeyCode.LeftShift))
        {
            PlayerDashing = true;
        } else
        {
            PlayerDashing = false;
        }

        if (Input.GetKey(KeyCode.F))
        {
            PlayerStunning = true;
        } else
        {
            PlayerStunning = false;
        }

        if (PlayerDashing && GM.PlayerDashTimer <= 0 && GM.PlayerCurrentRage >= GM.DashRageCost)
        {
            PlayerDash();
        }
        if (PlayerStunning && GM.StunTimer <= 0 && GM.PlayerCurrentRage >= GM.StunRageCost)
        {
            PlayerStun();
        }

        transform.Translate(PlayerDirection * GM.PlayerMoveSpeed * Time.deltaTime);    //Moves the player according to the set direction
    }

    public void PlayerDash()
    {
        transform.Translate(PlayerDirection * GM.PlayerDashDistance);
        GM.PlayerDashTimer = GM.PlayerDashCooldown;
        GM.PlayerCurrentRage -= GM.DashRageCost;
    }
    public void PlayerStun()
    {
        Instantiate(Stun);
        GM.StunTimer = GM.StunCooldown;
        GM.PlayerCurrentRage -= GM.StunRageCost;
    }
    
}
