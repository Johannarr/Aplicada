using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    MapManager gameController;

    Vector3 enemyMovement;

    bool movingRight = true;

    float Speed = 5;

    public Transform groundDetection;

    RaycastHit2D groundInformation;

    float distance = 2;

    void Start()
    {

        gameController = GameObject.Find("GlobalScriptsText").GetComponent<MapManager>();
    }

    void Update()
    {
        gameObject.transform.Translate(Vector2.right * Speed * Time.deltaTime);

        groundInformation = Physics2D.Raycast(groundDetection.position,Vector2.down,distance);
        
        if (groundInformation.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0,-180,0);
                movingRight = false;

            }else
            {
                transform.eulerAngles = new Vector3(0,0,0);
                movingRight = true;
            }
        }
    }


    /*private void OnTriggerEnter2D(Collider2D other){


       if (other.gameObject.tag.ToString().Contains("Player"))
       {
           

            gameController.DecrementLives();

            AudioManager.Instance.PlaySoundEffect(AudioManager.SoundEffect.DamageTaken);   
       }

        
    }*/
}
