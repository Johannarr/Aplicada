using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKey2Controller : MonoBehaviour
{
  public AudioSource audioSource;
    
  GameController gameController;

    BoxCollider boxCollider;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        gameController = GameObject.Find("GlobalScriptsText").GetComponent<GameController>();
    }

    
    void Update()
    {


    }


    private void OnTriggerEnter (Collider other)
    {

        if (Input.GetKey("s") && Input.GetKey("d") == false && Input.GetKey("f") == false && Input.GetKey("a") == false)
        {

            audioSource.Play();
            gameController.IncrementScore();
            Destroy(other.gameObject);
        }
       

    }
}
