using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameController gameController;
    void Start()
    {
        gameController = GameObject.Find("GlobalScriptsText").GetComponent<GameController>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        Destroy (other.gameObject);
        gameController.DecrementLives();
        //AudioManager.Instance.PlaySoundEffect(AudioManager.SoundEffect.Explode);
    }
}


   