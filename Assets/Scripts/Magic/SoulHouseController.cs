using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulHouseController : MonoBehaviour
{
    public GameObject firstEffect;
    private GameObject fireSoul;
    private GameObject rotatorMagic;
    private FireSoulController fireSoulController;
    private GameObject toriiWall;


    void Awake()
    {
        fireSoul = GameObject.Find("FireSoul");
        fireSoulController = fireSoul.GetComponent<FireSoulController>();
    }
    void Start()
    {
        toriiWall = GameObject.Find("ToriiWall_1");
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "FireMagic")
        {
            rotatorMagic = Instantiate(firstEffect, transform.position, Quaternion.identity);
            Invoke("FireSoulSet", 6.5f);
            Invoke("DestroySoulHouse", 6.5f);
            // Invoke("FireSoulSet", 4.0f);  //InvokeメソッドはオブジェクトをDestroyした時、呼び出すメソッドが存在しなくなるため実行されない
        }
    }

    public void DestroySoulHouse()
    {
        Destroy(gameObject);
        Destroy(rotatorMagic);
        // Destroy(toriiWall);
    }

    public void FireSoulSet()
    {
        fireSoul.SetActive(true);
    }
}
