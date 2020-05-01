using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTracker : MonoBehaviour
{
    public Image HealthUI;
    public Text HealthNumber;
    public GameMaster GM;
    public GameObject GMobj;

    void Awake()
    {
        GMobj = GameObject.Find("GM");
        GM = GMobj.GetComponent<GameMaster>();
        GM.PlayerCurrentHealth = GM.PlayerMaxHealth;
    }

    void Update()
    {
        HealthUI.fillAmount = GM.PlayerCurrentHealth / GM.PlayerMaxHealth;
        HealthNumber.text = GM.PlayerCurrentHealth.ToString("#.");
    }
}
