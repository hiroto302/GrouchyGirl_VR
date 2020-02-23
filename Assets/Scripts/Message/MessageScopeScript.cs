using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageScopeScript : MonoBehaviour
{

    private MessageScopeScript messageScopeScript;
    void Start()
    {
        messageScopeScript = gameObject.GetComponent<MessageScopeScript>();
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player" && col.GetComponent<MoveController_FirstStage>().GetState() != MoveController_FirstStage.State.Talk)
            {
              // playerが近づいたら会話アイコンの表示
                col.GetComponent<MessageTalkScript>().SetConversationPartner(transform.parent.gameObject);
            }
    }

    void OnTriggerExit(Collider col) {
        if (col.tag == "Player" && col.GetComponent<MoveController_FirstStage>().GetState() != MoveController_FirstStage.State.Talk)
        {
            // playerが範囲外に遠ざかったら会話相手から外す
            col.GetComponent<MessageTalkScript>().ResetConversationPartner(transform.parent.gameObject);
        }
    }
}
