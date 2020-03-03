using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackedByMagic : MonoBehaviour
{
    public GameObject damageEffect;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "FireMagic")
        {
            Instantiate(damageEffect, transform.position, Quaternion.identity);
            DamageAnim();
            Invoke("DestroyZombie", 3.0f);
        }
    }

    //アニメーションランダム再生
    public void DamageAnim()
    {
        int x = Random.Range(1, 3);
        if(x == 1)
        {
            animator.SetTrigger("Damage");
        }
        else if(x == 2)
        {
            animator.SetTrigger("Damage2");
        }
        else if(x == 3)
        {
            animator.SetTrigger("Damage3");
        }
    }
    public void DestroyZombie()
    {
        Destroy(gameObject);
    }
}
