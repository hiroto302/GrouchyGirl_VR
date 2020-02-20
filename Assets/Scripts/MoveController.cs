using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// コントローラーでplayer移動するために、CameraRigにRigidbodyを追加し、これを利用する方法も検討
public class MoveController : MonoBehaviour
{
    private Rigidbody rb;
    private float moveSpeed = 5.0f;
    private float punchPower = 5.0f;
    private float angleSpeed = 10.0f;

    private Transform tf;

    bool isFirst = true;  //Punchの最初のimpulseを判定するフラグ

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        tf = gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        //右スティックの値を格納、右側に倒すとｘ軸１に近づき、左に倒すと-1に近ずく。上下の場合、ｙ軸方向。ｚの値はない。最大値は１で、最小値は−１である。
        Vector3 rightStick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        //ｙ軸をｚ軸に変換
        Vector3 velocity = new Vector3(rightStick.x /10, 0, rightStick.y / 10);

        // rb.velocity = velocity * moveSpeed;  //加速度を与えて移動

        tf.Translate(velocity);

        //左スティック操作で角度を変換
        Vector3 leftStick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector3 angle = new Vector3(0, leftStick.x * angleSpeed, 0);
        //回転した時身体方向へ進むように修正すること
        // rb.angularVelocity = angle * angleSpeed;

        tf.Rotate(angle / 2);

    }

    //怒らせて、殴られた後後方に吹き飛ぶ
    public void PunchPower()
    {
        if(isFirst)
        {
            isFirst = false;
            // Vector3 firstImpulse = new Vector3 (0, 0, -10.0f);
            Vector3 firstImpulse = new Vector3 (0, 0, -25.0f);
            rb.AddForce(firstImpulse, ForceMode.Impulse);
        }
    }

    public void secondPunchPower()
    {
        // Vector3 distance = new Vector3(0, 0, -1.0f);
        Vector3 distance = new Vector3(0, 0, -4.0f);
        rb.velocity = distance * punchPower;
    }
}
