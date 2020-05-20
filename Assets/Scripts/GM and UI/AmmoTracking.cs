using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoTracking : MonoBehaviour
{
    public Image AmmoUI;                                                //Reference to the UI Image (CHECK GM)
    public Image AmmoUI2;
    public Text AmmoNumber;
    public bool Reloading;                                              //Checks if the player is currently reloading
    public float DisplayAmount;                                         //The displayed amount of bullets (CHECK GM AND PLAYERGUN, should always be full(MagazineSize) or Empty)
    float ReloadTimer;                                                  //Counts the reload time
    public GameMaster GM;
    public GameObject GMobj;
    private void Awake()
    {
        GMobj = GameObject.Find("GM");
        GM = GMobj.GetComponent<GameMaster>();
    }
    void Update()
    {
        if (Reloading)
        {
            DisplayAmount += Time.deltaTime / ReloadTimer;
            AmmoUI.fillAmount = DisplayAmount;
            AmmoUI2.fillAmount = DisplayAmount;

            if (DisplayAmount >= 1)
            {
                Reloading = false;
            }
        } else
        {
            ReloadTimer = GM.PlayerReloadDelay;
            DisplayAmount =  GM.PlayerCurrentBullets / GM.PlayerMagazineSize;
            AmmoUI.fillAmount = DisplayAmount;
            AmmoUI2.fillAmount = DisplayAmount;
        }
        AmmoNumber.text = GM.PlayerCurrentBullets.ToString("#.");
    }
}
