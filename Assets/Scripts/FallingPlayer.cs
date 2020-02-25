using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FallingPlayer : MonoBehaviour
{
    Vector3 playerPosition;
    float yPosition;
    void Start()
    {

    }
    void Update()
    {
        playerPosition = gameObject.transform.position;
        yPosition = playerPosition.y;
        if(yPosition < -10.0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
