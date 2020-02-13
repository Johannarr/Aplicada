using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyController : MonoBehaviour
{
    
    GameController gameController;

    BoxCollider boxCollider;
    void Start()
    {
        gameController = GameObject.Find("GlobalScriptsText").GetComponent<GameController>();
    }

    
    void Update()
    {

        if (Input.GetKey("right"));
        {
            //boxCollider = gameObject.GetComponent<BoxCollider>();

            //boxCollider
        }

    }


    private void OnTriggerEnter (Collider other)
    {

        gameController.IncrementScore();
        Destroy(other.gameObject);

    }
}
