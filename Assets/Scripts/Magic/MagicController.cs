using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : MonoBehaviour
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
            //右手操作
            if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || Input.GetKeyDown(KeyCode.A))
            {
                OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.RTouch);
                Instantiate(magicPrefab, gameObject.transform.position, Quaternion.identity, gameObject.transform);
                Debug.Log("右から発生");

            }
            else if(OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
            {
                OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            }

            //左手操作
            if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown(KeyCode.S))
            {
                OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.LTouch);
                Instantiate(magicPrefab, gameObject.transform.position, Quaternion.identity, gameObject.transform);
                Debug.Log("左から発生");
            }
            else if(OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
            {
                OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
            }
        }
    }
}
