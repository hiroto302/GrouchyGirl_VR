using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchCharacter : MonoBehaviour
{
    private ZombieController moveEnemy;

    void Start() {
        moveEnemy = GetComponentInParent<ZombieController>();
    }

    void OnTriggerEnter(Collider col)
    {
        //プレイヤーキャラクターを発見
        if (col.tag == "Hand")
        {
            Debug.Log("1つめ通過");
            ZombieController.State state = moveEnemy.GetState();
            if(state != ZombieController.State.Chase)
            {
                Debug.Log("2つめ通過");
                // moveEnemy.SetState(ZombieController.State.Chase, col.transform);
                moveEnemy.SetState(ZombieController.State.Chase, col.transform);
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.tag == "Hand")
        {
            Debug.Log("見失う");
            moveEnemy.SetState(ZombieController.State.Wait);
        }
    }
}
