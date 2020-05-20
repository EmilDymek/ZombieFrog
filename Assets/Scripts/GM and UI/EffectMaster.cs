using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectMaster : MonoBehaviour
{
    public GameMaster GM;
    public GameObject GMobj;

    //Here be variables
    public float ImpactEffectTimer;


    private void Awake()
    {
        GMobj = GameObject.Find("GM");
        GM = GMobj.GetComponent<GameMaster>();
    }
}
