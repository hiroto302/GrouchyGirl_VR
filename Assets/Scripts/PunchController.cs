// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// //CharacterControllerをアタッチしたオブジェクトに対する、パンチに合わせて吹っ飛ばす
// public class PunchController : MonoBehaviour
// {

//     private CharacterController characterController;

//     // private float punchPower = 5.0f;
//     bool isFirst = false;  //Punchの最初のimpulseを判定するフラグ

//     // // // キャラクターの速度
//     private Vector3 velocity;
//     Vector3 firstImpulse;

//     void Start()
//     {
//         characterController = GetComponent<CharacterController>();
//         firstImpulse = new Vector3 (0, 0, -25.0f);
//     }
//     void Update()
//     {
//         // if(characterController.isGrounded) {

//         // }
//         // velocity.y += Physics.gravity.y * Time.deltaTime;  //重力 UnityメニューのEdit→Project Settings→Physicsで設定されている値
//         if(isFirst == true)
//         {
//             velocity = firstImpulse;
//         }
//         characterController.Move(velocity * Time.deltaTime);
//     }

//     //怒らせて、殴られた後後方に吹き飛ぶ
//     public void PunchPower()
//     {
//         isFirst = true;

//         characterController.Move(firstImpulse);
//     }

// }
