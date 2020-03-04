using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMagic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Breakable")
        {
            Debug.Log("Breakableにふれたよ");
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "SampleZombie")
        {
            
        }

        if(other.gameObject.tag == "Soul")
        {
            
        }
    }
}
