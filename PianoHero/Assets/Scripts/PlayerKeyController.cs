using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyController : MonoBehaviour
{

    GameController gameController;

    void Start()
    {
        // obtenemos el gameconbroller que esta ubicado en GlobalScripsText
        gameController = GameObject.Find("GlobalScriptsText").GetComponent<GameController>();
    }

    
    void Update()
    {

        // Si el touch toca en cualquier lugar que no sea la tecla entrara aqui
        if (Input.touchCount > 0)
        {
            gameController.DecrementLives();  
        }
  

    }


    // cuando el mouse o el touch toque el objeto se entrara a la funcion, es necesario que el objeto en cuestion tenga collider para que funcione
    void OnMouseDown()
    {

        gameController.IncrementScore();
        Destroy(gameObject); 

        //AudioManager.Instance.PlaySoundEffect(AudioManager.SoundEffect.Capture);  
    }
}
