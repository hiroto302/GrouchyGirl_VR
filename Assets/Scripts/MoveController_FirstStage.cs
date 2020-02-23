using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveController_FirstStage : MonoBehaviour
{

    public enum State
    {
        Normal,
        Talk
    }

    // Playerの状態
    private State state;
    private MessageTalkScript messageTalkScript;

    private Message message;

    GameObject messageUI;

    GameObject searchArea;
    GameObject messagePanel;


    private Rigidbody rb;
    private float punchPower = 5.0f;
    private float angleSpeed = 5.0f;

    private Vector3 velocity;  //playerの動き速度
    private Vector3 angle;  //playerの進行角度

    private Transform tf;

    bool isFirst = true;  //Punchの最初のimpulseを判定するフラグ




    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        tf = gameObject.GetComponent<Transform>();
        state = State.Normal;
        messageTalkScript = gameObject.GetComponent<MessageTalkScript>();
        messageUI = GameObject.Find("MessageUI");
        message = messageUI.GetComponent<Message>();
        searchArea = GameObject.Find("SearchArea");
        messagePanel = GameObject.Find("MessagePanel");
    }

    void Update()
    {
        if(state == State.Normal)
        {
            // if(messageTalkScript.GetConversationPartner() != null && Input.GetKeyDown(KeyCode.S))
            if(messageTalkScript.GetConversationPartner() != null && OVRInput.GetDown(OVRInput.Button.One))
            {
                SetState(State.Talk);
            }
        }
        //右スティックの値を格納、右側に倒すとｘ軸１に近づき、左に倒すと-1に近ずく。上下の場合、ｙ軸方向。ｚの値はない。最大値は１で、最小値は−１である。
        Vector3 rightStick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        //ｙ軸をｚ軸に変換
        Vector3 velocity = new Vector3(rightStick.x /20, 0, rightStick.y / 20);
        //左スティック操作で角度を変換
        Vector3 leftStick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector3 angle = new Vector3(0, leftStick.x * angleSpeed, 0);
        tf.Translate(velocity);
        tf.Rotate(angle / 2);

            // // デバッグ用 操作
            // if(Input.GetKeyDown(KeyCode.D))
            // {
            //     Vector3 velocity = new Vector3( 1, 0, 0);
            //     tf.Translate(velocity);
            // }
            // if(Input.GetKeyDown(KeyCode.A))
            // {
            //     Vector3 velocity = new Vector3( -1, 0, 0);
            //     tf.Translate(velocity);
            // }
            // if(Input.GetKeyDown(KeyCode.W))
            // {
            //     Vector3 velocity = new Vector3( 0, 0, 1);
            //     tf.Translate(velocity);
            // }
            // if(Input.GetKeyDown(KeyCode.X))
            // {
            //     Vector3 velocity = new Vector3( 0, 0, -1);
            //     tf.Translate(velocity);
            // }
            // if(Input.GetKeyDown(KeyCode.Q))
            // {
            //     Vector3 angle = new Vector3( 15, 0, 0);
            //     tf.Rotate(angle);
            // }
            // if(Input.GetKeyDown(KeyCode.E))
            // {
            //     Vector3 angle = new Vector3( -15, 0, 0);
            //     tf.Rotate(angle);
            // }
    }


    // 状態変更と初期設定
    public void SetState(State state)
    {
        this.state = state;
        if(state == State.Talk)
        {
            message.MessageStart();
            messageTalkScript.MessageIconOff();
            messageTalkScript.enabled = false;
            Destroy(searchArea);
            messagePanel.GetComponent<Image>().enabled = true;
        }
    }

    public State GetState()
    {
        return state;
    }


    //怒らせて、殴られた後後方に吹き飛ぶ機能
    public void PunchPower()
    {
        if(isFirst)
        {
            isFirst = false;
            Vector3 firstImpulse = new Vector3 (0, 0, -25.0f);
            rb.AddForce(firstImpulse, ForceMode.Impulse);
        }
    }

    public void secondPunchPower()
    {
        Vector3 distance = new Vector3(0, 0, -4.0f);
        rb.velocity = distance * punchPower;
    }
}
