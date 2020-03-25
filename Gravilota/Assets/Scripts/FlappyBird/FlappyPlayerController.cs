using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyPlayerController : MonoBehaviour
{
   
    const float Y_MIN_LIMIT = -4.2f;
    const float Y_MAX_LIMIT = 4.2f;

    [SerializeField]
    Vector3 MovementSpeed = new Vector3(0,10f), _deltaPos;
    float _lastVerticalAxis;
    GameControllerFlappy gameController;
    
   
    // Start is called before the first frame update
    private void Start()
    {
      gameController = GameObject.Find("GlobalScriptText").GetComponent<GameControllerFlappy>(); 
    }

    // Update is called once per frame
    void Update()
    {
       
        if (_lastVerticalAxis != Input.GetAxis("Vertical"))
        {
            _lastVerticalAxis = Input.GetAxis("Vertical");
        }
            
        _deltaPos = MovementSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        gameObject.transform.Translate(_deltaPos);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                    Mathf.Clamp(gameObject.transform.position.y, Y_MIN_LIMIT, Y_MAX_LIMIT),
                                                    gameObject.transform.position.z);
    }

    private void OnTriggerEnter (Collider other)
    {
       
            if (other.tag == "Obst"){
            gameController.GameOver();
            FlappyAudioManager.Instance.PlaySoundEffect(FlappyAudioManager.SoundEffect.ObstaculeCapture); 
            FlappyAudioManager.Instance.PlaySoundEffect(FlappyAudioManager.SoundEffect.GameOver); 
                        
            }  

            if (other.tag == "Score")
            {
                gameController.IncrementScore();
                FlappyAudioManager.Instance.PlaySoundEffect(FlappyAudioManager.SoundEffect.ScoreCapture);
            } 

    }

  
}
