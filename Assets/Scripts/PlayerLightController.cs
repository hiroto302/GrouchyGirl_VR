using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 移動に伴い掴んだオブジェクトがワープしたように移動してしまうのてそれを解決する方法
// 掴んだものをカスタムハンドの子オブジェクトにすれば良い
public class PlayerLightController : MonoBehaviour
{
    GameObject rightHand;
    GameObject leftHand;
    void Start()
    {
        rightHand = GameObject.Find("RightHandAnchor");
        leftHand = GameObject.Find("LeftHandAnchor");
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        // if(other.gameObject.tag == "Hand" && OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        if(other.gameObject.tag == "Hand" && OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.LTouch);
            gameObject.transform.parent = rightHand.transform;
        }
        else if(other.gameObject.tag == "Hand" && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {
            gameObject.transform.parent = leftHand.transform;
        }
    }
}
