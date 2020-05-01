using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactEffectBehaviour : MonoBehaviour
{
    public GameMaster GM;
    public EffectMaster EM;
    public GameObject GMobj;

    private void Awake()
    {
        GMobj = GameObject.Find("GM");
        GM = GMobj.GetComponent<GameMaster>();
        EM = GMobj.GetComponent<EffectMaster>();
    }

    void Update()
    {
        EM.ImpactEffectTimer -= Time.deltaTime;
        if (EM.ImpactEffectTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
