using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTracker : MonoBehaviour
{
    public Image HealthUI;
    public float CurrentHealth;
    public float MaxHealth;
    public float DisplayAmount;

    void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    void Update()
    {
        DisplayAmount = CurrentHealth / MaxHealth;
        HealthUI.fillAmount = DisplayAmount;
    }

    public void TakeDamage(float Damage)
    {

    }
}
