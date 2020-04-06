using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovementController : MonoBehaviour
{
    float _XAcceleration = -9.8f;
    float _XCurrentSpeed = 0;
    Vector3 _deltaPos;
    GameControllerHunter gameController;
    public bool IsGameOver;  

    
    
    private void Awake()
    {
        _deltaPos = new Vector3();
        
    }

    private void Start()
    {
      gameController = GameObject.Find("GlobalScriptsText").GetComponent<GameControllerHunter>(); 
    }

  
    // Update is called once per frame
    void Update()
    {
       
        _deltaPos.x= _XCurrentSpeed * Time.deltaTime + (_XAcceleration * Mathf.Pow(Time.deltaTime,2))/2;
        gameObject.transform.Translate(_deltaPos);

        _XCurrentSpeed += _XAcceleration * Time.deltaTime;
    }


     private void OnTriggerEnter (Collider other)
    {
       
            if (other.tag == "Cannon"){
            gameController.IncrementScore();
            Destroy (other.gameObject);
            HunterWorldAudioManager.Instance.PlaySoundEffect(HunterWorldAudioManager.SoundEffect.Capture);  
                        
            }  

            

    }
}
