using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiDamage : MonoBehaviour
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

    // public void OnCollisionEnter(Collision other)
    // {
    //     if(other.gameObject.tag == "Sword")
    //     {
    //         OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.RTouch);
    //         OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.LTouch);
    //         Debug.Log("発動したよ");
    //         Destroy(gameObject);
    //     }
    // }
    // public void OnTriggerEnter(Collider other)
    // {
    //     if(other.gameObject.tag == "Sword")
    //     {
    //         OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.RTouch);
    //         OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.LTouch);
    //         Debug.Log("発動したよ");
    //         // Destroy(transform.parent.gameObject);
    //         Destroy(gameObject);
    //     }
    // }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Sword")
        {
            OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.LTouch);
            Debug.Log("発動したよ");
            // Destroy(transform.parent.gameObject);
            Destroy(gameObject);
            torii.Decrease(1);
        }
    }
}
