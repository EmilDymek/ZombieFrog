using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float PlayerSpeed;                                                   //Keeps Player Speed
    private Vector2 PlayerDirection;                                            //Keeps track of PlayerDirection
    private Rigidbody2D PlayerBody;                                                   //Keeps a reference to rigidbody
    public Vector3 PlayerPosition;

    void Start()                                                                //This is the Start function
    {
        PlayerBody = GetComponent<Rigidbody2D>();                                     //Initializes the rigidbody
    }


    void Update()                                                               //This is the update function
    {
        GetInput();                                                             //Calls the GetInput Function
        PlayerPosition = this.transform.position;
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

        transform.Translate(PlayerDirection * PlayerSpeed * Time.deltaTime);    //Moves the player according to the set direction
    }
}
