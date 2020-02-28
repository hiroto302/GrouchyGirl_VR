using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakString : MonoBehaviour
{
    private BreakToriiWall_1 torii;
    GameObject toriiWall;

    void Start()
    {
        toriiWall = GameObject.Find("ToriiWall_1");
        torii = toriiWall.GetComponent<BreakToriiWall_1>();
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Sword")
        {
            OVRInput.SetControllerVibration(0.1f, 0.1f, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(0.1f, 0.1f, OVRInput.Controller.LTouch);
            // Destroy(transform.parent.gameObject);
            transform.parent.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            Destroy(gameObject);

            torii.Decrease(1);
        }
    }
}
