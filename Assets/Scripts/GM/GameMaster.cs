using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameMaster : MonoBehaviour
{
    //HERE BE VARIABLES, CHECK GM FOR ALL VARIABLES

    //Player Gun
    public float PlayerFireRate;                    //Stores the fire rate (Eg. 0.073)
    public float PlayerGunDamage;                   //Stores the Gun Damage (Eg. 1.0)
    public float PlayerReloadDelay;                 //Stores the Gun Reload Delay (Eg. 0.65)
    public float PlayerMagazineSize;                //Stores the Max amount of bullets (Eg. 30)
    public float PlayerCurrentBullets;              //The current amount of bullets in the magazine (Start at PlayerMagazineBullets)
    //Player Health
    public float PlayerMaxHealth;                   //Max Health of the Player (Eg. 100)
    public float PlayerCurrentHealth;               //The current amount of player health (Start at PlayerMaxHealth)
    //Player Rage
    public float PlayerRageMax;                     //Max Rage of the Player (Eg. 100)
    public float PlayerCurrentRage;                 //Current Player Rage (Always start at 0)
    public float PlayerRageTickAmount;              //The amount of rage granted for each hit (eg. 0.075)
    public float PlayerRageDecay;                   //The rate of the Rage meter deterioration (Eg. 0.2)
    //Player Dash
    public float PlayerDashDistance;                //Stores the distance of the dash ability
    public float PlayerDashCooldown;
    public float PlayerDashTimer;
    public float DashRageCost;
    //Player Stun
    public float StunCooldown;
    public float StunTimer;
    public float StunRageCost;
    public float QuakeDuration;
    public float QuakeGrowth;
    //Player Other
    public float PlayerMoveSpeed;                   //Stores the speed of the player (Eg. 10)
    

    //Camera
    public float CameraFollowSpeed;                 //Stores the speed of which the camera will follow the player (Eg. 5)

}
