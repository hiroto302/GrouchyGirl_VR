using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HintBoard4: MonoBehaviour
{

    public GameObject hintText;
    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hand")
        {
            hintText.GetComponent<Text>().text = "鈍感なゾンビでも、前には立たないように気をつけて..";
        }
    }

    // private void OnCollisionEnter(Collision other)
    // {
    //     if(other.gameObject.tag == "Hand")
    //     {
    //         hintText.GetComponent<Text>().text = "彼に話しかけてみてよ...";
    //     }
    // }
}
