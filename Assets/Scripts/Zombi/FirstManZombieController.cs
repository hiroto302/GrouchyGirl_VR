﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class FirstManZombieController : MonoBehaviour
{
    public enum State
    {
        Wait,
        Walk,
        Attack,
        Damage,
        Death
    }

    private State state;
    private Animator animator;
    public GameObject damageEffect;
    public GameObject deathEffect;
    private NavMeshAgent navMeshAgent;
    private GameObject player;
    private Vector3 playerPosition;
    private float distance;
    private bool chase;
    private bool attack;
    [SerializeField]
    private int hp = 5;  //ゾンビの体力

    private float elapsedTime;  //遷移時間の計測
    void Start()
    {
        SetState(State.Wait);
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("OVRCameraRig");
        chase = false;
        attack = true;
    }

    void Update()
    {
        Debug.Log(state+"状態だよ");
        Debug.Log("attack = " + attack);
        Debug.Log("chase = " + chase);

        //フレーム毎に実行されている
        if(chase == true)
        {
            playerPosition = player.transform.position;
            navMeshAgent.SetDestination(playerPosition);

            if(attack == true)
            {
                distance = Vector3.Distance(transform.position, playerPosition);
                if(distance < 2.5f)
                {
                    SetState(State.Attack);  //アタック状態
                }
            }
        }

        if(state == State.Attack)
        {
            elapsedTime += Time.deltaTime;
            if(elapsedTime > 2.0f)
            {
                SetState(State.Walk);
            }
        }
        else if(state == State.Damage)
        {
            elapsedTime = Time.deltaTime;
            if(elapsedTime > 3.7f)
            {
                SetState(State.Walk);
            }
        }

    }

    public void SetState(State state)
    {
        this.state = state;
        if(state == State.Walk)
        {
            animator.SetTrigger("Walk");
            chase = true;
            attack = true;
        }
        else if (state == State.Attack)
        {
            animator.SetTrigger("Attack");
            chase = true;
            attack = false;
            elapsedTime = 0;
            // ここの記述がバグの原因となっている。
            // playerが攻撃する時、distanceが2.5f以下になるのでAttack状態のゾンビを攻撃することになる
            // その状態で攻撃を受けた時には、すでにInvoke("Walk",2.0f)が実行されていて、
            // damage状態でもすぐにWalk状態に遷移してしまうため挙動がおかしくなっていた
            // そこで,elapseTimeを導入し解決した
            // if(state != State.Damage)
            // {
            //     Invoke("Walk", 2.0f);
            // }
        }
        else if (state == State.Damage)
        {
            chase = false;
            attack = false;
            animator.SetTrigger("Damage");
            elapsedTime = 0;
            // if(state != State.Death)
            // {
                // Invoke("Walk", 4.0f);
            // Invoke("Walk", 4.0f);
            // }
        }
        else if (state == State.Death)
        {
            chase = false;
            attack = false;
            animator.SetTrigger("Death");
            Invoke("Death", 3.0f);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Sword")
        {
            OVRInput.SetControllerVibration(0.1f, 0.1f, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(0.1f, 0.1f, OVRInput.Controller.LTouch);
            GetState();
            if(state != State.Damage)
            {
                DecreaseHP(1);
            }
            // SetState(State.Damage);  //これもdecreaseHpのメソッド中に入れた方がいいかも
        }
        else if(other.gameObject.tag == "Hand")
        {
            GetState();
            if(state != State.Death || state != State.Damage)
            {
                AttackPlayer();
            }
        }

    }

    //ゾンビの体力
    public void DecreaseHP(int damage)
    {
        hp = hp - damage;
        if(0 < hp)
        {
            SetState(State.Damage);
            Instantiate(damageEffect, gameObject.transform.position, Quaternion.identity);
        }
        else if (hp == 0)
        {
            SetState(State.Death);
            Instantiate(deathEffect, gameObject.transform.position, Quaternion.identity);
        }
    }
    // playerへの攻撃し接触した時発動
    public void AttackPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // ゾンビの消滅
    public void Death()
    {
        Destroy(gameObject);
    }
    // 現在の状態取得
    public State GetState()
    {
        return state;
    }

    public void Walk()
    {
        SetState(State.Walk);
    }
}
