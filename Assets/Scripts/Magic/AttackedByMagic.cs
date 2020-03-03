using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackedByMagic : MonoBehaviour
{
    public GameObject damageEffect;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "FireMagic")
        {
            Debug.Log("魔法をくらったよ");
            Instantiate(damageEffect, transform.position, Quaternion.identity);
            animator.SetTrigger("Damage");
            Invoke("DestroyZombie", 3.0f);
        }
    }

    public void DestroyZombie()
    {
        Destroy(gameObject);
    }
}
