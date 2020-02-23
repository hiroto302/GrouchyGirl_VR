using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageTalkScript : MonoBehaviour
{
    // 会話可能な相手
    private GameObject conversationPartner;
    [SerializeField]
    private GameObject talkIcon = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void SetConversationPartner(GameObject partnerObj) {
        talkIcon.SetActive(true);
        conversationPartner = partnerObj;
    }

    public void ResetConversationPartner(GameObject parterObj) {
        // 会話相手がいない場合は何もしない
        if(conversationPartner == null) {
            return;
        }
        // 会話相手と引数で受け取った相手が同じインスタンスIDを持つなら会話相手をなくす GameObjectにはそれぞれ固有の（ユニークな）IDが付けられている
        if(conversationPartner.GetInstanceID() == parterObj.GetInstanceID()) {
            talkIcon.SetActive(false);
            conversationPartner = null;
        }
    }

    public GameObject GetConversationPartner() {
        return conversationPartner;
    }

    public void MessageIconOff()
    {
        talkIcon.SetActive(false);
    }
}
