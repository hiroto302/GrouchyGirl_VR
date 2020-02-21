using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRM;

public class Hand1 : MonoBehaviour
{
   public GameObject gameObj;
    VRMBlendShapeProxy proxy;
    Animator animator;
    void Start()
    {
        proxy = gameObj.GetComponent<VRMBlendShapeProxy>();
        this.animator = gameObj.GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Hand")
        {
            this.animator.SetTrigger("HandTrigger");
            // proxy.ImmediatelySetValue(BlendShapePreset.Blink_R, 1.0f);
            // proxy.ImmediatelySetValue("Angry", 1.0f);
            proxy.ImmediatelySetValue(BlendShapePreset.Angry, 1.0f);  //表情の変化 第一引数 BlendShapePreset key(表情の種類) 第二引数表情変化

            OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.LTouch);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Hand")
        {
            // proxy.ImmediatelySetValue(BlendShapePreset.Blink_R, 0);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
        }
    }
}

