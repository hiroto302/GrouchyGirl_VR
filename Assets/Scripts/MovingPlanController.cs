using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlanController : MonoBehaviour
{
    [SerializeField] float power = 5.0f;  //移動させる力
    Vector3 objPosition;
    void Start()
    {
        objPosition = this.transform.position;  //初期位置
    }

    void Update()
    {
        // this.transform.position = new Vector3(
        //     objPosition.x, objPosition.y, objPosition.z + Mathf.Sin(Time.time) * power );
        this.transform.position = new Vector3(
            objPosition.x, objPosition.y + Mathf.Sin(Time.time) * power, objPosition.z );
    }
}
