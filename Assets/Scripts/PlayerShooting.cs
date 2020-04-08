using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float FireTimer = 0.1f;                                           //Variable that sotres fire rate
    public float GunDamage = 1.0f;                                          //Variable that stores bullet damage
    Vector3 MousePos;                                                       //Variable to store mouse position
    Vector3 GunPos;                                                         //Variable to store gun direction
    public float Angle;                                                     //Variable to store the rotation
    public Transform Target;                                                //Gameobject reference (Store the crosshair gameobject in here)
    public Transform FirePoint01;                                           //GameObject reference (Store FirePoint01 gameobject in here)
    public GameObject Bullet01;                                             //GameObject reference (Store Bullet Prefab in here)
    public GameObject ImpactEffect;                                         //Gameobject Reference (Store Impact Effect here)
    public LineRenderer LineRend;                                           //Reference to a linerenderer
    bool Shooting = false;                                                  //Bool to keep track of wether or not the player is shooting

    void Update()
    {
        TurnGun();                                                          //Calls Turning function
        GetInput();                                                         //Calls the Input function
        FireTimer -= Time.deltaTime;                                        //Ticks down Fire Timer (Time between shots)
    }

    IEnumerator Shoot()
    {
        //Instantiate(Bullet01, FirePoint01.position, FirePoint01.rotation);                    //Instantiates a Bullet

        RaycastHit2D HitInfo = Physics2D.Raycast(FirePoint01.position, FirePoint01.right);      //Uses raycast to draw a line from the player (fire point) in the direction of the gun

        if (HitInfo)                                                                            //If the raycast detects something
        {
            GruntBehaviour Enemy = HitInfo.transform.GetComponent<GruntBehaviour>();            //Get the Enemy game component
            if (Enemy != null)                                                                  //If an enemy is detected
            {
                Enemy.TakeDamage(GunDamage);                                                    //Call Takedamage function in the enemy script and send the Gun Damage variable
            }
            Instantiate(ImpactEffect, HitInfo.point, Quaternion.identity);                      //Make an Impact effect, Where the bullet is, With locked rotation
            LineRend.SetPosition(0, FirePoint01.position);                                      //Sets first point of the line on the fire point position
            LineRend.SetPosition(1, HitInfo.point);                                             //Sets second point of the line at the detected object
        } else
        {
            LineRend.SetPosition(0, FirePoint01.position);                                      //Sets first point of the line on the fire point position
            LineRend.SetPosition(1, FirePoint01.position + FirePoint01.right * 100);            //Sets the second point of the line 100 units away from the firepoint in the direction of the gun
        }

        LineRend.enabled = true;                                                                //Draw the line
        yield return new WaitForSeconds(0.02f);                                                 //Wait for 0.02 seconds
        LineRend.enabled = false;                                                               //Hide the line
    }

    void GetInput()
    {
        if (Input.GetKey(KeyCode.Mouse0))                                                       //If the left mouse button is pressed
        {
            Shooting = true;                                                                    //Set Shooting bool to true
        } else
        {
            Shooting = false;                                                                   //Else set shooting bool to false
        }
        if (Shooting == true && FireTimer <= 0) {                                               //If the shooting condition is true
            FireTimer = 0.1f;                                                                   //Reset Firetimer
            StartCoroutine(Shoot());                                                            //Calls Shooting coroutine
        }
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
