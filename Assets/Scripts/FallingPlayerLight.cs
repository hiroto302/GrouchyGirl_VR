using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingPlayerLight : MonoBehaviour
{
    Vector3 playerLightPosition;
    float yPosition;

    void Start()
    {
        
    }

    void Update()
    {
        playerLightPosition = gameObject.transform.position;
        yPosition = playerLightPosition.y;
        if(yPosition < -10.0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
