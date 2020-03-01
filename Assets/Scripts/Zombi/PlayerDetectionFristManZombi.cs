using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectionFristManZombi : MonoBehaviour
{
    private FirstManZombieController zombie;
    private GameObject[] firstManZombie;
    void Start()
    {
        firstManZombie = GameObject.FindGameObjectsWithTag("FirstZombie");
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Hand")
        {
            foreach(var firstZombie in firstManZombie)
            {
                zombie = firstZombie.GetComponent<FirstManZombieController>();
                zombie.SetState(FirstManZombieController.State.Walk);
            }
        }
    }
}
