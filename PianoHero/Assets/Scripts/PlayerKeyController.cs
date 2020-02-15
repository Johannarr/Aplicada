using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyController : MonoBehaviour
{

    public AudioSource audioSource;
    
    GameController gameController;

    BoxCollider boxCollider;
    void Start()
    {

        gameController = GameObject.Find("GlobalScriptsText").GetComponent<GameController>();
    }

    
    void Update()
    {
        // testing
       /* if (Input.GetKeyDown("w"))
        {
            gameController.IncrementScore();
            Destroy(gameObject);       
        }*/

        // si se hace un touch a la pantalla entrara al if y aumentara score y destruira el objeto
        if (Input.touchCount > 0)
        {
            gameController.IncrementScore();
            audioSource.Play();
            Destroy(gameObject);       
        }

    }

}
