using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject Player;                                            //Public variable to store a reference to the player game object
    private Vector3 Offset;                                              //Private variable to store the offset distance between the player and camera

    void Start()
    {
        Offset = transform.position - Player.transform.position;         //Calculate and store the offset value by getting the distance between the player's position and camera's position.
    }

    void LateUpdate()
    {
        transform.position = Player.transform.position + Offset;        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
    }
}
