using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMagic : MonoBehaviour
{
    private MagicController magicController;
    private GameObject[] magicHands;

    public GameObject effectPrefab;
    void Start()
    {
        magicHands = GameObject.FindGameObjectsWithTag("MagicHand");
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
            foreach(var magicHand in magicHands)
            {
                magicController = magicHand.GetComponent<MagicController>();
                magicController.magic = true;
            }
        }
    }
}
