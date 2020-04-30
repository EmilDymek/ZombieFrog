using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageTracker : MonoBehaviour
{
    public Image RageUI;                                                //Reference to the UI Image (CHECK GM)
    public Text RageNumber;
    public GameMaster GM;

    void Update()
    {
        if (GM.PlayerCurrentRage > 0)
        {
            GM.PlayerCurrentRage -= Time.deltaTime * GM.PlayerRageDecay;
        }
        RageUI.fillAmount = GM.PlayerCurrentRage / GM.PlayerRageMax;
        RageNumber.text = GM.PlayerCurrentRage.ToString("#.00");
    }

    public void RageTick()
    {
        if (GM.PlayerCurrentRage < GM.PlayerRageMax)
        {
            GM.PlayerCurrentRage += GM.PlayerRageTickAmount;
        }
    }
}
