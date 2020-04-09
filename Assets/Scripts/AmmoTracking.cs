using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoTracking : MonoBehaviour
{
    public Image AmmoUI;
    public PlayerShooting playerShooting;
    public bool Reloading;
    float SpentShells;
    public float DisplayAmmount;
    float ReloadTime;

    private void Awake()
    {
        playerShooting.GetComponent<PlayerShooting>();
    }

    void Update()
    {
        if (Reloading)
        {
            DisplayAmmount += Time.deltaTime / ReloadTime;
            AmmoUI.fillAmount = DisplayAmmount;

            if (DisplayAmmount >= 1)
            {
                Reloading = false;
            }
        } else
        {
            ReloadTime = playerShooting.ReloadDelay;
            SpentShells = playerShooting.MagazineSize - playerShooting.PlayerBullets;
            DisplayAmmount = SpentShells / playerShooting.MagazineSize;
            AmmoUI.fillAmount = 1.0f - DisplayAmmount;
        }
    }
}
