using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeatroyIce : MonoBehaviour
{
    GameObject ice;
    void Start()
    {
        ice = GameObject.Find("IceStairPlane");
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fire")
        {
            Destroy(ice);
        }
    }
}
