using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 会話範囲に入った時,実行するスクリプト
public class ConversationScopeScript : MonoBehaviour
{

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player" && col.GetComponent<MoveController>().GetState() != MoveController.State.Talk)
            {
              // playerが近づいたら会話相手として自分のゲームオブジェクトを渡す
              // transform.parent.gameObjectでこのスクリプトをアタッチしている子オブジェクトの親オブジェクト(ここではFirstMan)を指定して代入
              col.GetComponent<PlayerTalkScript>().SetConversationPartner(transform.parent.gameObject);
            }
    }

    void OnTriggerExit(Collider col) {
        if (col.tag == "Player" && col.GetComponent<MoveController>().GetState() != MoveController.State.Talk)
        {
            // playerが範囲外に遠ざかったら会話相手から外す
            col.GetComponent<PlayerTalkScript>().ResetConversationPartner(transform.parent.gameObject);
        }
    }

}