using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float FireRate = 0.0f;
    public float Damage = 1.0f;
    Vector3 MousePos;                                                       //Variable to store mouse position
    Vector3 GunPos;                                                         //Variable to store gun direction
    public float Angle;                                                     //Variable to store the rotation
    public Transform Target;                                                //Gameobject reference (Store the crosshair gameobject in here)
    public Transform FirePoint01;                                           //GameObject reference (Store FirePoint01 gameobject in here)
    public GameObject Bullet01;                                             //GameObject reference (Store Bullet Prefab in here)

    void Start()
    {
        
    }


    void Update()
    {
        TurnGun();                                                          //Calls Turning function
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(Bullet01, FirePoint01.position, FirePoint01.rotation);
    }

    void TurnGun()
    {
        MousePos = Input.mousePosition;                                         //Updates the variable and stores the current mouse position
        GunPos = Camera.main.WorldToScreenPoint(transform.position);            //Updates the variable and stores the gun position
        MousePos.x = MousePos.x - GunPos.x;                                     //Adjusts the variable
        MousePos.y = MousePos.y - GunPos.y;                                     //  --//--

        float angle = Mathf.Atan2(MousePos.y, MousePos.x) * Mathf.Rad2Deg;      //Calculates the Rotation of the gun
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));        //Rotates the gun
    }
}
