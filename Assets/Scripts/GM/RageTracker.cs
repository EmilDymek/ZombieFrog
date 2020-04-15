using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageTracker : MonoBehaviour
{
    public Image RageUI;                                                //Reference to the UI Image (CHECK GM)
    public float DisplayAmount;                                         //The Displayed amount of stored rage (CHECK GM, SHOULD ALWAYS BE 0)
    public float DecayAmount;                                           //The rate at which the rage bar deteriorates (CHECK GM)
    public float TickAmount;                                            //The amount of rage gained per hit (CHECK GM)

    void Update()
    {
        if (DisplayAmount > 0)
        {
            DisplayAmount -= Time.deltaTime * DecayAmount;
        }
        RageUI.fillAmount = DisplayAmount;
    }

    public void RageTick()
    {
        if (DisplayAmount < 1)
        {
            DisplayAmount = DisplayAmount + TickAmount;
        }
    }
}
