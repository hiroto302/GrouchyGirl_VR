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

    public GameObject damageEffect;  //攻撃された時のeffect
    public GameObject explosion;  //爆発prefab

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
            Invoke("Death", 2.5f);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Sword")
        {
            OVRInput.SetControllerVibration(0.2f, 0.2f, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(0.2f, 0.2f, OVRInput.Controller.LTouch);
            // Destroy(transform.parent.gameObject);
            Instantiate(damageEffect, gameObject.transform.position, Quaternion.identity);
            SetState(State.Death);
            torii.Decrease(1);
        }
    }

    public void Death()
    {
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
