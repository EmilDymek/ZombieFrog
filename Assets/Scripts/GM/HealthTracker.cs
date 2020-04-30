using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTracker : MonoBehaviour
{
    public Image HealthUI;
    public Text HealthNumber;
    public GameMaster GM;

    void Awake()
    {
        GM.PlayerCurrentHealth = GM.PlayerMaxHealth;
    }

    void Update()
    {
        HealthUI.fillAmount = GM.PlayerCurrentHealth / GM.PlayerMaxHealth;
        HealthNumber.text = GM.PlayerCurrentHealth.ToString("#.");
    }
}
