using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private Vector3 StartPos;                                               //Variable for position before tracking
    private Vector3 TargetPos;                                              //Variable for target position
    public Transform FollowTarget;                                          //Gameobject (Put the player object in here)
    public GameMaster GM;
    
    void Start()
    {
        StartPos = transform.position;                                      //Stores the starting position
    }

    void LateUpdate()
    {
        TargetPos = new Vector3(FollowTarget.position.x, FollowTarget.position.y, transform.position.z);                //Updates target position to the FollowTarget's position
        Vector3 Velocity = (TargetPos - transform.position) * GM.CameraFollowSpeed;                                     //Stores the distance between the current possition and the target position
        transform.position = Vector3.SmoothDamp(transform.position, TargetPos, ref Velocity, 1.0f, Time.deltaTime);     //Moves the Camera to the target position using Smoothdamp function
    }
}
