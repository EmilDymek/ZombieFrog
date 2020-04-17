using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTracker : MonoBehaviour
{
    public Image HealthUI;
    public float DisplayAmount;
    public GameMaster GM;

    void Awake()
    {
        GM.PlayerCurrentHealth = GM.PlayerMaxHealth;
    }

    void Update()
    {
        DisplayAmount = GM.PlayerCurrentHealth / GM.PlayerMaxHealth;
        HealthUI.fillAmount = DisplayAmount;
    }
}
