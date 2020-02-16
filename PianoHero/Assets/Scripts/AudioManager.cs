using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    public static AudioManager Instance;

    //Agrego los distintos audio source que se utilizaran
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
    
    // Este enum sirve para poder identificar los sonidos que se utilizaran en cada etapa y se utilizaran mediante el switch
    //case de mas abajo
    public enum SoundEffect
    {
        Start,
        Lost,
        Capture,
        GameOver,

        Win
    }

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
