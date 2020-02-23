using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageScopeScript1 : MonoBehaviour
{

    private MessageScopeScript1 messageScopeScript;

    void Start()
    {

        messageScopeScript = gameObject.GetComponent<MessageScopeScript1>();
        messageScopeScript.enabled = false;
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player" && col.GetComponent<MoveController>().GetState() != MoveController.State.Talk)
            {
              // playerが近づいたら会話アイコンの表示
              // transform.parent.gameObjectでこのスクリプトをアタッチしている子オブジェクトの親オブジェクト(ここではFirstMan)を指定して代入

            col.GetComponent<MessageTalkScript>().SetConversationPartner(transform.parent.gameObject);
            //   if(Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.One))
            //   {
            //       messageScopeScript.enabled = false;
            //   }

            }
    }
    void OnTriggerExit(Collider col) {
        if (col.tag == "Player" && col.GetComponent<MoveController>().GetState() != MoveController.State.Talk)
        {
            // playerが範囲外に遠ざかったら会話相手から外す
            col.GetComponent<MessageTalkScript>().ResetConversationPartner(transform.parent.gameObject);
        }
    }
}
