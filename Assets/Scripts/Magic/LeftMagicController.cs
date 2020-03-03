using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMagicController : MonoBehaviour
{
    public GameObject magicPrefab;
    public bool magic;

    void Start()
    {
        magic = false;
    }

    void Update()
    {
        if(magic == true)
        {
            //左手操作
            if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown(KeyCode.S))
            {
                OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.LTouch);
                Instantiate(magicPrefab, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            }
            else if(OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
            {
                OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
            }
        }
    }
}
