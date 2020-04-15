using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoTracking : MonoBehaviour
{
    public Image AmmoUI;                                                //Reference to the UI Image (CHECK GM) 
    public GameMaster GM;
    public bool Reloading;                                              //Checks if the player is currently reloading
    public float DisplayAmount;                                         //The displayed amount of bullets (CHECK GM AND PLAYERGUN, should always be full(MagazineSize) or Empty)
    float ReloadTimer;                                                  //Counts the reload time

    void Update()
    {
        if (Reloading)
        {
            DisplayAmount += Time.deltaTime / ReloadTimer;
            AmmoUI.fillAmount = DisplayAmount;

            if (DisplayAmount >= 1)
            {
                Reloading = false;
            }
        } else
        {
            ReloadTimer = GM.PlayerReloadDelay;
            DisplayAmount =  GM.PlayerCurrentBullets / GM.PlayerMagazineSize;
            AmmoUI.fillAmount = DisplayAmount;
        }
    }
}
