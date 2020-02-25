using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseFloor : MonoBehaviour
{
    GameObject raisedFloor;
    GameObject toriiWall;
    void Start()
    {
        raisedFloor = GameObject.Find("RaisedFloor");
        raisedFloor.SetActive(false);
        toriiWall = GameObject.Find("ToriiWall");
    }

    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "PlayerLight")
        {
            Debug.Log("trigger呼ばれたよ");
            raisedFloor.SetActive(true);
            toriiWall.SetActive(false);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "PlayerLight")
        {
            Debug.Log("trigger呼ばれたよ");
            raisedFloor.SetActive(false);
            toriiWall.SetActive(true);
        }
    }

}
