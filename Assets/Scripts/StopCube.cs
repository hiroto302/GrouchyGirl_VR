using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCube : MonoBehaviour
{
    private int hp;
    void Start()
    {
        hp = 3;
    }

    void Update()
    {
        
    }

    public void DecreaseHp()
    {
        hp --;
        if(hp == 0)
        {
            Destroy(gameObject);
        }
    }
}
