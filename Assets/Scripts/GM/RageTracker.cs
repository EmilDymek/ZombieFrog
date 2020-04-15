using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageTracker : MonoBehaviour
{
    public Image RageUI;                                                //Reference to the UI Image (CHECK GM)
    public GameMaster GM;
    public float DisplayAmount;                                         //The Displayed amount of stored rage (CHECK GM, SHOULD ALWAYS BE 0)

    void Update()
    {
        if (DisplayAmount > 0)
        {
            DisplayAmount -= Time.deltaTime * GM.PlayerRageDecay;
        }
        RageUI.fillAmount = DisplayAmount;
    }

    public void RageTick()
    {
        if (DisplayAmount < 1)
        {
            DisplayAmount = DisplayAmount + GM.PlayerRageTickAmount;
        }
    }
}
