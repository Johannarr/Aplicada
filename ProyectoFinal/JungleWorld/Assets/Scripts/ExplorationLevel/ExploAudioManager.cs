using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploAudioManager : MonoBehaviour
{
    // Start is called before the first frame update
public static ExploAudioManager Instance;

    //Agrego los distintos audio source que se utilizaran en esta clase
    //public AudioSource Lost;

    public AudioSource CaptureCoin;
    public AudioSource CapturePowerUp;
    public AudioSource CaptureFruit;

    public AudioSource Song;

    public AudioSource GameOver;

    public AudioSource Win;


   
    private void Awake()
    {
        Instance = this;
    }
    

    public enum SoundEffect
    {
        Start,
        //Lost,
        CaptureCoin,
        CapturePowerUp,
        CaptureFruit,
        GameOver,
        Win,
        
    }

    
    public void PlaySoundEffect(SoundEffect type)
    {
        switch (type)
        {
            
        

        case SoundEffect.CaptureCoin:
            CaptureCoin.Play();
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
         case SoundEffect.CapturePowerUp:
            CapturePowerUp.Play();
            break;
        case SoundEffect.CaptureFruit:
            CaptureFruit.Play();
            break;

        }
    }

}
