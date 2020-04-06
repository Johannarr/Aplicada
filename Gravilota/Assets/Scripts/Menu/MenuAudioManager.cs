using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioManager : MonoBehaviour
{
    
    public static MenuAudioManager Instance;

    public AudioSource Hover;

    public AudioSource Click;

    public AudioSource Song;


    private void Awake()
    {
        Instance = this;
    }

    
    public enum SoundEffect
    {
        Hover,
        Click,
        Song
    }
    

    public void PlaySoundEffect(SoundEffect type)
    {
        switch (type)
        {

        case SoundEffect.Song:
            Song.Play();
            break;

        case SoundEffect.Hover:
            Hover.Play();
            break;

        case SoundEffect.Click:
            Click.Play();
            break;;

        }
    }

}
