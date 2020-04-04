using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocoAudioManager : MonoBehaviour
{
    public static CrocoAudioManager Instance;
    
    public AudioSource FishCapture;

    public AudioSource EnemyCapture;

    public AudioSource Song;

    public AudioSource GameOver;

    public AudioSource Win;

    private void Awake()
    {
        Instance = this;
    }
    
    public enum SoundEffect
    {
        BadCapure,
        Capture,

        Start,

        GameOver,

        Win,
    }

    public void PlaySoundEffect(SoundEffect type)
    {
        switch (type)
        {
        case SoundEffect.Capture:
            FishCapture.Play();
            break;

        case SoundEffect.BadCapure:
            EnemyCapture.Play();
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
