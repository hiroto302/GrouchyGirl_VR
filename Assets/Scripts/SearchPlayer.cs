using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPlayer : MonoBehaviour
{
    private ZombieController zombi;

    void Start() {
        zombi = GetComponentInParent<ZombieController>();
    }

    void OnTriggerEnter(Collider col)
    {
        //プレイヤーキャラクターを発見
        if (col.tag == "Hand")
        {
            ZombieController.State state = zombi.GetState();
            if(state != ZombieController.State.Attack)
            {
                zombi.SetState(ZombieController.State.Attack);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
