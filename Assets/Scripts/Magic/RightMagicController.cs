using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMagicController : MonoBehaviour
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
            }
            else if(OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
            {
                OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            }
        }
    }
}
