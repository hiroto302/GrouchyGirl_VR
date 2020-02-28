using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectionNormalZombi : MonoBehaviour
{
    private NormalZombiController zombi;
    private GameObject normalZombi;
    void Start()
    {
        normalZombi = GameObject.Find("BreakablZombie_Normal");
        zombi = normalZombi.GetComponent<NormalZombiController>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Hand")
        {
            zombi.SetState(NormalZombiController.State.Walk);
            Debug.Log("trigger発動");
        }
    }
}
