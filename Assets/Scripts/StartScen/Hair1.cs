using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRM;

public class Hair1 : MonoBehaviour
{
    public GameObject gameObj;
    VRMBlendShapeProxy proxy;
    void Start()
    {
        proxy = gameObj.GetComponent<VRMBlendShapeProxy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Hand")
        {
            // proxy.ImmediatelySetValue("Extra", 1.0f);  //第一引数にはstring型を使用 表情の変化方法
        // proxy.ImmediatelySetValue("Angry", 1.0f);  //第一引数にはstring型を使用 表情の変化方法
            proxy.ImmediatelySetValue(BlendShapePreset.Angry, 1.0f);  //表情の変化 第一引数 BlendShapePreset key(表情の種類) 第二引数表情変化
            OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.LTouch);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Hand")
        {
            // proxy.ImmediatelySetValue("Extra", 0);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
        }
    }

}
