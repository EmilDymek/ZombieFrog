using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerShooting : MonoBehaviour
{
    public GameMaster GM;                                                   //Reference to the GM
    public GameObject GMobj;
        
    Vector3 MousePos;                                                       //Variable to store mouse position
    Vector3 GunPos;                                                         //Variable to store gun direction
    private float FireTimer;                                                //Variable that resets to firerate on each trigger pull
    public Transform Crosshair;                                             //Gameobject reference (Store the crosshair gameobject in here)
    public Transform FirePoint01;                                           //GameObject reference (Store FirePoint01 gameobject in here)
    public GameObject Bullet01;                                             //GameObject reference (Store Bullet Prefab in here)
    public GameObject ImpactEffect;                                         //Gameobject Reference (Store Impact Effect here)
    public LineRenderer LineRend;                                           //Reference to a linerenderer
    public AmmoTracking ammoTracking;                                       //Reference to Ammotracking

    //temp variabeles, move to GM later
    public float stunCooldown = 5;
    public float stunTimer = 0;

        private void Awake()
        {
            GMobj = GameObject.Find("GM");
            GM = GMobj.GetComponent<GameMaster>();
            GM.PlayerCurrentBullets = GM.PlayerMagazineSize;
            ammoTracking = GMobj.GetComponent<AmmoTracking>();
        }

        void Update()
        {
            TurnGun();                                                          //Calls Turning function
            GetInput();                                                         //Calls the Input function
            if (FireTimer >= 0)
            {
                FireTimer -= Time.deltaTime;                                    //Ticks down Fire Timer (Time between shots)
            }
        }

        void InstantiateShoot()
        {
            Instantiate(Bullet01, FirePoint01.position, FirePoint01.rotation);                      //Instantiates a Bullet
        }

        IEnumerator RaycastShoot()
        {
            RaycastHit2D HitInfo = Physics2D.Raycast(FirePoint01.position, FirePoint01.right);      //Uses raycast to draw a line from the player (fire point) in the direction of the gun

            if (HitInfo && HitInfo.collider.tag != "Player" && HitInfo.collider.tag != "Stun" && HitInfo.collider.tag != "Bullet"
                && HitInfo.collider.tag != "StunCollider")                                        //If the raycast detects something that isn't tagged as player 
            {
                EnemyAI Enemy = HitInfo.transform.GetComponent<EnemyAI>();            //Get the Enemy game component
                if (Enemy != null)                                                                  //If an enemy is detected
                {
                    Enemy.Damage(GM.PlayerGunDamage);                                           //Call Takedamage function in the enemy script and send the Gun Damage variable
                }
                Instantiate(ImpactEffect, HitInfo.point, Quaternion.identity);                      //Make an Impact effect, Where the bullet is, With locked rotation
                LineRend.SetPosition(0, FirePoint01.position);                                      //Sets first point of the line on the fire point position
                LineRend.SetPosition(1, HitInfo.point);                                             //Sets second point of the line at the detected object
            }
            else
            {
                LineRend.SetPosition(0, FirePoint01.position);                                      //Sets first point of the line on the fire point position
                LineRend.SetPosition(1, FirePoint01.position + FirePoint01.right * 100);            //Sets the second point of the line 100 units away from the firepoint in the direction of the gun
            }
            LineRend.enabled = true;                                                                //Draw the line
            yield return new WaitForSeconds(0.02f);                                                 //Wait for 0.02 seconds
            LineRend.enabled = false;                                                               //Hide the line
        }

        IEnumerator Reload()
        {
            yield return new WaitForSeconds(GM.PlayerReloadDelay);                                           //Waits for the reload delay
            GM.PlayerCurrentBullets = GM.PlayerMagazineSize;                                                           //Refills the players magazine

        }

        void GetInput()
        {
            if (Input.GetKey(KeyCode.Mouse0) && FireTimer <= 0 && GM.PlayerCurrentBullets > 0 && ammoTracking.Reloading == false)                 //If the left mouse button is pressed AND FireTimer is at 0 AND the player has more than 0 bullets AND the player isn't reloading
            {
                FireTimer = GM.PlayerFireRate;                                                                                                     //Reset Firetimer
                GM.PlayerCurrentBullets -= 1;                                                                                                     //Ticks down the player bullet count
                                                                                                                                                  //InstantiateShoot();                                                                                                   //Calls the shooting function for instantiation shooting
                StartCoroutine(RaycastShoot());                                                                                         //Calls Shooting coroutine for raycast shooting
            }
            if (Input.GetKey(KeyCode.R))
            {
                if (ammoTracking.Reloading == false && GM.PlayerCurrentBullets != GM.PlayerMagazineSize)
                {
                    ammoTracking.Reloading = true;
                    ammoTracking.DisplayAmount = 0;
                    StartCoroutine(Reload());
                }
            }
            //if (Input.GetKey(KeyCode.F))
            //{
            //    if (stunTimer <= 0 && GM.PlayerCurrentRage >= GM.StunRageCost)
            //    {
            //        GM.PlayerCurrentRage -= GM.StunRageCost;
                    

            //    }
            //}
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

