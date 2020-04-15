using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoTracking : MonoBehaviour
{
    public Image AmmoUI;                                                //Reference to the UI Image (CHECK GM) 
    public PlayerShooting playerShooting;                               //Reference to another script
    public GameMaster GM;
    public bool Reloading;                                              //Checks if the player is currently reloading
    float SpentShells;                                                  //The difference between max amount of bullets and current bullets
    public float DisplayAmount;                                         //The displayed amount of bullets (CHECK GM AND PLAYERGUN, should always be full(MagazineSize) or Empty)
    float ReloadTime;                                                   //The speed of the reload (CHECK GM)

    private void Awake()
    {
        playerShooting.GetComponent<PlayerShooting>();
    }

    void Update()
    {
        if (Reloading)
        {
            DisplayAmount += Time.deltaTime / ReloadTime;
            AmmoUI.fillAmount = DisplayAmount;

            if (DisplayAmount >= 1)
            {
                Reloading = false;
            }
        } else
        {
            ReloadTime = GM.PlayerReloadDelay;
            SpentShells = GM.PlayerMagazineSize - playerShooting.PlayerBullets;
            DisplayAmount = SpentShells / GM.PlayerMagazineSize;
            AmmoUI.fillAmount = 1.0f - DisplayAmount;
        }
    }
}
