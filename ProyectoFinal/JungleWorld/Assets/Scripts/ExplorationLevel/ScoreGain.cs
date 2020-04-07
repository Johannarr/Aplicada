using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGain : MonoBehaviour
{
    // Start is called before the first frame update
    
    GameControllerExplo gameController;
    void Start()
    {
        gameController = GameObject.Find("GlobalScriptsText").GetComponent<GameControllerExplo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            gameController.IncrementScore();
            ExploAudioManager.Instance.PlaySoundEffect(ExploAudioManager.SoundEffect.CaptureCoin);
           Destroy(gameObject);
        }

    }
}
