using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneController : MonoBehaviour
{

    public GameController gameController;
    void Start()
    {
        // obtenemos el gameconbroller que esta ubicado en GlobalScripsText
        gameController = GameObject.Find("GlobalScriptsText").GetComponent<GameController>();
    }


    
    // Esta funcion se encarga de destruir el con el que colissiona, ademas de destuirlo este decrementara las vidas y tocara un sonido de fallo
    //Recibe como parametro el objeto con el que colisiona
     void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        gameController.DecrementLives();

        AudioManager.Instance.PlaySoundEffect(AudioManager.SoundEffect.Lost);
    }
}
