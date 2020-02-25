using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HintBoard3: MonoBehaviour
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
            hintText.GetComponent<Text>().text = "ライトを台に置いてみるといいかも";
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
