using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyController : MonoBehaviour
{

    GameController gameController;

    Vector2 KeyPosition;

    void Start()
    {

        gameController = GameObject.Find("GlobalScriptsText").GetComponent<GameController>();
    }

    
    void Update()
    {


        // testing

        KeyPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);


       /* if (Input.GetTouch(0).position == KeyPosition)
        {
            gameController.IncrementScore();
            Destroy(gameObject);  
        }*/


       /* if (Input.GetKeyDown("w"))
        {
            gameController.IncrementScore();
            Destroy(gameObject);       
        }*/

        // si se hace un touch a la pantalla entrara al if y aumentara score y destruira el objeto
       /* if (Input.touchCount > 0)
        {
            gameController.IncrementScore();
            audioSource.Play();
            Destroy(gameObject);       
        }*/

    }


    // cuando el mouse o el touch toque el objeto se entrara a la funcion
    void OnMouseDown()
    {

       /* if (Input.mousePosition.x == gameObject.transform.position.x && Input.mousePosition.y == gameObject.transform.position.y)
        {
             
        }*/

        gameController.IncrementScore();
        Destroy(gameObject); 

        AudioManager.Instance.PlaySoundEffect(AudioManager.SoundEffect.Capture);  
        
    }

}
