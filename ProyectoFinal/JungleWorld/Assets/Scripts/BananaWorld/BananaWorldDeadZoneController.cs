using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaWorldDeadZoneController : MonoBehaviour
{
    // Start is called before the first frame update

    public BananaWorldGameController gameController;
    void Start()
    {
        gameController = GameObject.Find("GlobalScriptsText").GetComponent<BananaWorldGameController>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        Destroy (other.gameObject);
        gameController.DecrementLives();
        BananaWorldAudioManager.Instance.PlaySoundEffect(BananaWorldAudioManager.SoundEffect.Lost);
    }
}


   