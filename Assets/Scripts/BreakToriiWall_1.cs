using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakToriiWall_1 : MonoBehaviour
{

    int HP;
    void Start()
    {
        HP = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(HP);
    }

    public void Decrease(int damage)
    {
        HP = HP - damage;
        if(HP == 0)
        {
            Destroy(gameObject);
        }
    }
}
