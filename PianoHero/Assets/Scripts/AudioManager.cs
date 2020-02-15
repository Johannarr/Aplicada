using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    public static AudioManager Instance;
    public AudioSource KeyLost;

    public AudioSource KeyCapture;

    private void Awake()
    {
        Instance = this;
    }
    
    public enum SoundEffect
    {
        Lost,
        Capture
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
            
        }
    }
}
