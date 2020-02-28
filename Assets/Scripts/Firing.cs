using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    public GameObject fire;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fire")
        {
            Destroy(other.transform.parent.gameObject);
            // Debug.Log("発火したよ");
            Instantiate(fire, gameObject.transform.position, Quaternion.identity);
            Invoke("endFire", 5.0f);
        }
    }

    public void endFire()
    {
        Destroy(fire);
    }
}


