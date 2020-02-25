using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLight : MonoBehaviour
{
    [SerializeField] float power = 0.5f;
    Vector3 objPosition;
    void Start()
    {
        objPosition = this.transform.position;
    }

    void Update()
    {
        this.transform.position = new Vector3(
            objPosition.x, objPosition.y + Mathf.Sin(Time.time) * power, objPosition.z);
    }
}
