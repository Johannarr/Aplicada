using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    public static AudioManager Instance;

    //Agrego los distintos audio source que se utilizaran en esta clase
    public AudioSource KeyLost;

    public AudioSource KeyCapture;

    public AudioSource Song;

    public AudioSource GameOver;

    public AudioSource Win;


    // implementando singleton para poder utilizar el audiomanager en cualquier otra clase
    private void Awake()
    {
        Instance = this;
    }
    
    // Este enum sirve para poder identificar los sonidos que se utilizaran en cada etapa
    public enum SoundEffect
    {
        Start,
        Lost,
        Capture,
        GameOver,
        Win
    }

    
    // En esta funcion se especifica mediante switch case, los distintos casos en lo que se utilizara cada sonido
    //Esta funcion tiene como parametro el enum definido aqui arriba, esta funcion no returna nada.
    public void PlaySoundEffect(SoundEffect type)
    {
        switch (type)
        {
            
        case SoundEffect.Lost:
            KeyLost.Play();
            break;

        case SoundEffect.Capture:
            KeyCapture.Play();
            break;
            
        case SoundEffect.Start:
            Song.Play();
            break;

        case SoundEffect.GameOver:
            Song.Stop();
            GameOver.Play();
            break;

        case SoundEffect.Win:
            Song.Stop();
            Win.Play();
            break;
        }
    }
}
