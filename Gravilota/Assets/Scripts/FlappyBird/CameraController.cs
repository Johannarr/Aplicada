using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
 public GameObject Player;

    Vector3 position;
    void Start()
    {
        position = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            transform.position = Player.transform.position + position;
        }
        
    }
}
