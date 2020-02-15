using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneController : MonoBehaviour
{

    public GameController gameController;
    void Start()
    {
        gameController = GameObject.Find("GlobalScriptsText").GetComponent<GameController>();
    }


     void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        gameController.DecrementLives();

        AudioManager.Instance.PlaySoundEffect(AudioManager.SoundEffect.Lost);
    }
}
