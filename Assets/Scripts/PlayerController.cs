// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//     // // // キャラクター操作に関して
//     private CharacterController characterController;
//     // // // キャラクターの速度
//     private Vector3 velocity;
//     // // キャラクターの歩くスピード
//     // [SerializeField]
//     // private float walkSpeed = 2.0f;
//     // // キャラクターの走るスピード
//     // [SerializeField]
//     // private float runSpeed = 4.0f;
//     // [SerializeField]
//     // private float angleSpeed = 10.0f;

//     // void Start()
//     // {
//     //     characterController = GetComponent<CharacterController>();
//     // }
//     void Update()
//     {
//         if(characterController.isGrounded) {
//             // velocity = Vector3.zero; // Vector3.zeroを入れて速度を0にする

//             //右スティックの値を格納、右側に倒すとｘ軸１に近づき、左に倒すと-1に近ずく。上下の場合、ｙ軸方向。ｚの値はない。最大値は１で、最小値は−１である。
//             // Vector3 rightStick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
//             //ｙ軸をｚ軸に変換
//             // Vector3 velocity = new Vector3(rightStick.x /10, 0, rightStick.y / 10);

//         //     //左スティック操作で角度を変換
//         //     Vector3 leftStick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
//         //     // var angleInput = new Vector3(0, leftStick.x * angleSpeed, 0);
//         //     var angleInput = new Vector3(leftStick.x * angleSpeed,0, leftStick.y * angleSpeed);

//         //     // var input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));  //横軸の入力,縦軸の入力
//             // var input = new Vector3(rightStick.x, 0f, rightStick.y);  //横軸の入力,縦軸の入力
            

//         //     // input.magnitudeで入力（ベクトル）の長さを取得
//             // if(input.magnitude > 0.1f)
//             // {
//             //     //transform.LookAt 引数で指定したベクトルの方向を向かせるメソッド
//             //     // input.normalizedで入力の単位ベクトル（長さが1のベクトルで方向を得る）を足すことで現在の位置に入力した方向を足して、その方向を向かせるようにします。
//             //     if (input.magnitude > 0.5f) {
//             //         // velocity += transform.forward * runSpeed;
//             //         velocity += input * runSpeed;
//             //     } else {
//             //         velocity += input * walkSpeed;
//             //     }
//             // }

//         //     if(angleInput.magnitude > 0.1f)
//         //     {
//         //         transform.LookAt(transform.position + angleInput.normalized);
//         //     }
//         }
//         velocity.y += Physics.gravity.y * Time.deltaTime;  //重力 UnityメニューのEdit→Project Settings→Physicsで設定されている値
//         characterController.Move(velocity * Time.deltaTime);
//     }
// }
