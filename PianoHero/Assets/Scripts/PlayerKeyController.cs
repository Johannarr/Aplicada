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

        // Script para que pierda vida si no toco las teclas, presenta fallas
       /* if (Input.touchCount > 0)
        {
            gameController.DecrementLives();  
        }*/

       

    }




    // cuando el mouse o el touch toque el objeto se entrara a la funcion, es necesario que el objeto en cuestion tenga collider para que funcione
    void OnMouseDown()
    {

        gameController.IncrementScore();
        Destroy(gameObject); 

        AudioManager.Instance.PlaySoundEffect(AudioManager.SoundEffect.Capture);  
        
    }

}
