using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyAudioManager : MonoBehaviour
{
    public static FlappyAudioManager Instance;
    public AudioSource ObstaculeCapture;

    public AudioSource ScoreCapture;

    public AudioSource Song;

    public AudioSource GameOver;

    private void Awake()
    {
        Instance = this;
    }
    
    public enum SoundEffect
    {
        ObstaculeCapture,
        ScoreCapture,

        Start,

        GameOver
    }

    public void PlaySoundEffect(SoundEffect type)
    {
        switch (type)
        {
        case SoundEffect.ObstaculeCapture:
            ObstaculeCapture.Play();
            break;

        case SoundEffect.ScoreCapture:
            ScoreCapture.Play();
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
