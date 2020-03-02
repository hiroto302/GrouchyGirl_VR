using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class FirstManZombieController_Ver2 : MonoBehaviour
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
    [SerializeField]
    private int hp = 5;  //ゾンビの体力
    private float elapsedTime;  //状態変更までの時間

    private GameObject toriiWall;
    void Start()
    {
        SetState(State.Wait);
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("OVRCameraRig");

        toriiWall = GameObject.Find("ToriiWall_1");

    }

    void Update()
    {
        //フレーム毎に実行されている
        distance = Vector3.Distance(transform.position, playerPosition);

        if(state == State.Walk)
        {
            playerPosition = player.transform.position;
            navMeshAgent.SetDestination(playerPosition);
            if(distance < 2.5f)
            {
                SetState(State.Attack);  //アタック状態
            }
        }
        else if (state == State.Attack)
        {
            playerPosition = player.transform.position;
            navMeshAgent.SetDestination(playerPosition);
            elapsedTime += Time.deltaTime;
            if(elapsedTime > 2.0f)
            {
                if(state != State.Damage)
                {
                    SetState(State.Walk);
                }
            }
        }
        else if (state == State.Damage)
        {
            elapsedTime += Time.deltaTime;
            if(elapsedTime > 3.5f)
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
        }
        else if (state == State.Attack)
        {
            elapsedTime = 0;
            animator.SetTrigger("Attack");
        }
        else if (state == State.Damage)
        {
            elapsedTime = 0;
            animator.SetTrigger("Damage");
        }
        else if (state == State.Death)
        {
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
        }
        else if(other.gameObject.tag == "Hand")
        {
            if(state == State.Attack)
            {
                AttackPlayer();
            }
        }

    }

    //ゾンビの体力減少
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
    // ゾンビの消滅 および ToriiWall の破壊
    public void Death()
    {
        Destroy(toriiWall);
        Destroy(gameObject);
    }
    // 現在の状態取得
    public State GetState()
    {
        return state;
    }
}
