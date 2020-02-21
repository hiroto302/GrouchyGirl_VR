using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRM;

public class Face1 : MonoBehaviour
{
    public GameObject gameObj;
    VRMBlendShapeProxy proxy;
    void Start()
    {
        proxy = gameObj.GetComponent<VRMBlendShapeProxy>();
        //初期のデフォルメ 表情
        // proxy.ImmediatelySetValue("StartFace", 1.0f);  //第一引数にはstring型を使用 表情の変化方法
        proxy.ImmediatelySetValue(BlendShapePreset.Neutral, 1.0f);
    }

    void Update()
    {
        
    }
}
