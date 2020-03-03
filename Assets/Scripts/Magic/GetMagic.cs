using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// コメントアウトの記述は両手同時に魔法を発生させるMagicControllerスクリプト対応の記述
public class GetMagic : MonoBehaviour
{
    private LeftMagicController leftMagicController;
    private RightMagicController rightMagicController;
    // private MagicController magicController;

    private GameObject leftHand;
    private GameObject rightHand;
    // private GameObject[] magicHands;

    public GameObject effectPrefab;
    void Start()
    {
        leftHand = GameObject.Find("CustomHandLeft");
        rightHand = GameObject.Find("CustomHandRight");
        // magicHands = GameObject.FindGameObjectsWithTag("MagicHand");
    }

    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hand")
        {
            Instantiate(effectPrefab, gameObject.transform.position, Quaternion.identity);
            OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.LTouch);
            OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.RTouch);
            leftMagicController = leftHand.GetComponent<LeftMagicController>();
            leftMagicController.magic = true;
            rightMagicController = rightHand.GetComponent<RightMagicController>();
            rightMagicController.magic = true;
        }
    }

    // public void OnTriggerEnter(Collider other)
    // {
    //     if(other.gameObject.tag == "Hand")
    //     {
    //         Instantiate(effectPrefab, gameObject.transform.position, Quaternion.identity);
    //         OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.LTouch);
    //         OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.RTouch);
    //         foreach(var magicHand in magicHands)
    //         {
    //             magicController = magicHand.GetComponent<MagicController>();
    //             magicController.magic = true;
    //         }
    //     }
    // }
}
