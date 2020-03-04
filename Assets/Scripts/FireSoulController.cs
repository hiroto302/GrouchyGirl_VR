using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSoulController : MonoBehaviour
{
    public bool release;
    private float countTime = 10.0f;
    private GameObject toriiWall;

    void Awake()
    {
        toriiWall = GameObject.Find("ToriiWall_1");
    }
    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        countTime -= Time.deltaTime;

        if(countTime > 9.0f)
        {
            transform.Translate(0, 0.025f, 0);
        }
        else if(countTime > 7.0f)
        {
            transform.Translate(0, 0.05f, 0);
        }
        else if(countTime > 5.0f)
        {
            transform.Translate(0, 0.1f, 0);
            // transform.Translate(0, 1.0f, 0);
        }
        // else if(countTime > 3.0f)
        else if(countTime > 4.5f)
        {
            transform.Translate(0, 1.0f, 0);
            Destroy(toriiWall);
        }
        else if(countTime > 0)
        {
            Destroy(gameObject);
        }
    }
}
