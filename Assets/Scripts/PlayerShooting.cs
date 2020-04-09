using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float FireTimer = 0.01f;                                          //Variable that sotres fire rate
    public float ReloadDelay = 1.0f;                                        //Variable that stores the time to reload
    public float GunDamage = 1.0f;                                          //Variable that stores bullet damage
    Vector3 MousePos;                                                       //Variable to store mouse position
    Vector3 GunPos;                                                         //Variable to store gun direction
    public float Angle;                                                     //Variable to store the rotation
    public float PlayerBullets;                                             //Variable that stores the current ammount of bullets in the player's gun
    public float MagazineSize;                                              //Variable that stores the fixed Magazine Size
    public Transform Target;                                                //Gameobject reference (Store the crosshair gameobject in here)
    public Transform FirePoint01;                                           //GameObject reference (Store FirePoint01 gameobject in here)
    public GameObject Bullet01;                                             //GameObject reference (Store Bullet Prefab in here)
    public GameObject ImpactEffect;                                         //Gameobject Reference (Store Impact Effect here)
    public LineRenderer LineRend;                                           //Reference to a linerenderer
    public AmmoTracking ammoTracking;

    private void Awake()
    {
        ammoTracking.GetComponent<AmmoTracking>();
    }

    void Update()
    {
        TurnGun();                                                          //Calls Turning function
        GetInput();                                                         //Calls the Input function
        if (FireTimer > 0)
        {
            FireTimer -= Time.deltaTime;                                        //Ticks down Fire Timer (Time between shots)
        }
    }

    void Shoot()
    {
        Instantiate(Bullet01, FirePoint01.position, FirePoint01.rotation);                    //Instantiates a Bullet
        PlayerBullets -= 1;
    }

    IEnumerator RaycastShoot()
    {
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
        PlayerBullets -= 1;
        LineRend.enabled = true;                                                                //Draw the line
        yield return new WaitForSeconds(0.02f);                                                 //Wait for 0.02 seconds
        LineRend.enabled = false;                                                               //Hide the line
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(ReloadDelay);
        PlayerBullets = MagazineSize;

    }

    void GetInput()
    {
        if (Input.GetKey(KeyCode.Mouse0) && FireTimer <= 0 && PlayerBullets > 0 && ammoTracking.Reloading == false)                 //If the left mouse button is pressed AND FireTimer is at 0 AND the player has more than 0 bullets
        {
            FireTimer = 0.074f;                                                                                                     //Reset Firetimer
            Shoot();
            //StartCoroutine(RaycastShoot());                                                                                       //Calls Shooting coroutine for raycast shooting
        } 
        if (Input.GetKey(KeyCode.R))
        {
            if (ammoTracking.Reloading == false && PlayerBullets != MagazineSize)
            {
                ammoTracking.Reloading = true;
                ammoTracking.DisplayAmmount = 0;
                StartCoroutine(Reload());
            }
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
