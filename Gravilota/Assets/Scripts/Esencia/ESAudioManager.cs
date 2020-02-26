using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESAudioManager : MonoBehaviour
{
    public static ESAudioManager Instance;
    public AudioSource BallExplosion;

    public AudioSource BallCapture;

    public AudioSource Song;

    public AudioSource GameOver;

    private void Awake()
    {
        Instance = this;
    }
    
    public enum SoundEffect
    {
        Explode,
        Capture,

        Start,

        GameOver
    }

    public void PlaySoundEffect(SoundEffect type)
    {
        switch (type)
        {
        case SoundEffect.Capture:
            BallCapture.Play();
            break;

        case SoundEffect.Explode:
            BallExplosion.Play();
            break;

        case SoundEffect.Start:
            Song.Play();
            break;

        case SoundEffect.GameOver:
            Song.Stop();
            GameOver.Play();
            break;
            
        }
    }
}
