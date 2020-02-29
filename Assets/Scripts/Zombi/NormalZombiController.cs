using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NormalZombiController : MonoBehaviour
{
    public enum State
    {
        Wait,
        Walk,
        Attack,
        Death
    }
    public State state;
    private Animator animator;
    public GameObject damageEffect;
    private NavMeshAgent navMeshAgent;
    private GameObject player;  //ターゲットのプレイヤー
    Vector3 playerPosition;  //プレイヤーの位置
    private bool walk;

    private float distance;  //プレイヤーとの距離


    void Start()
    {
        SetState(State.Wait);
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("OVRCameraRig");
        walk = false;
    }

    void Update()
    {
        if(walk == false)
        {
            return;
        }
        playerPosition = player.transform.position;
        navMeshAgent.SetDestination(playerPosition);  //プレイヤーを追跡
        distance = Vector3.Distance(transform.position, playerPosition);
        if(distance < 2.5f)
        {
            SetState(State.Attack);
        }
        else if (distance < 0.5f)
        {
            // AttackPlayer();
        }
    }

    public void SetState(State state)
    {
        this.state = state;
        if(state == State.Walk)
        {
            animator.SetTrigger("Walk");
            walk = true;
        }
        else if(state == State.Attack)
        {
            animator.SetTrigger("Attack");
            walk = true;
            if(state != State.Death)
            {
                SetState(State.Walk);
            }
        }
        else if(state == State.Death)
        {
            walk = false;
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
            Instantiate(damageEffect, gameObject.transform.position, Quaternion.identity);
            SetState(State.Death);
        }
        else if(other.gameObject.tag == "Hand")
        {
            AttackPlayer();  //子オブジェクトのSearchAreatriggerに反応してる！？  ifの条件式に条件を追加、または他の方法で実装 今回は距離の計算でAttackを実装
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public void AttackPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
