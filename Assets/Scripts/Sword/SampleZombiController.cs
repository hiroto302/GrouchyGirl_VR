using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 剣で破壊する練習用のゾンビ
public class SampleZombiController : MonoBehaviour
{
    public enum State
    {
        Wait,
        Death
    }

    private State state;
    private Animator animator;

    private BreakToriiWall_1 torii;
    GameObject toriiWall;

    void Start()
    {
        SetState(State.Wait);
        animator = gameObject.GetComponent<Animator>();
        toriiWall = GameObject.Find("ToriiWall_1");
        torii = toriiWall.GetComponent<BreakToriiWall_1>();
    }

    void Update()
    {
        
    }

    public void SetState(State state)
    {
        this.state = state;
        if(state == State.Death)
        {
            animator.SetTrigger("Damage");
            Invoke("Death", 3.0f);
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Sword")
        {
            OVRInput.SetControllerVibration(0.2f, 0.2f, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(0.2f, 0.2f, OVRInput.Controller.LTouch);
            Debug.Log("発動したよ");
            // Destroy(transform.parent.gameObject);
            // Destroy(gameObject);
            SetState(State.Death);
            torii.Decrease(1);
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
