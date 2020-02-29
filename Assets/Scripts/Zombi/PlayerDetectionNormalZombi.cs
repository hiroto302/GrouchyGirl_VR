using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectionNormalZombi : MonoBehaviour
{
    private NormalZombiController zombi;
    // private GameObject normalZombi;
    GameObject[] normalZombis;  //複数のゾンビをコントロールするために配列に変更
    void Start()
    {
        // normalZombi = GameObject.Find("BreakablZombie_Normal");
        // zombi = normalZombi.Getcomponent<NormalZombiController>();

        normalZombis = GameObject.FindGameObjectsWithTag("NormalZombie");
    }

    void Update()
    {
        
    }

    // void OnTriggerEnter(Collider col)
    // {
    //     if (col.tag == "Hand")
    //     {
    //         zombi.SetState(NormalZombiController.State.Walk);
    //     }
    // }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Hand")
        {
            foreach(var enemy in normalZombis)
            {
                zombi = enemy.GetComponent<NormalZombiController>();
                zombi.SetState(NormalZombiController.State.Walk);
            }
        }
    }
}
