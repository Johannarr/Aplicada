using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyPlayerController : MonoBehaviour
{
   
    //public TextMesh PlayerLivesText;
    public GameObject GameOverText;
    public bool IsGameOver;
    const float Y_MIN_LIMIT = -4.2f;
    const float Y_MAX_LIMIT = 4.2f;

    [SerializeField]
    Vector3 MovementSpeed = new Vector3(0,10f), _deltaPos;
    ScoreController _scoreController; 
    int _lives = 3;
    Animator _animator;
    float _lastVerticalAxis;
    ESWebClient _webClient;

   
    // Start is called before the first frame update
    private void Awake()
    {
        _webClient = GameObject.Find("GlobalScriptsText").GetComponent<ESWebClient>();
         _animator = GetComponent<Animator>();
         _scoreController = GameObject.Find("GlobalScriptsText").GetComponent<ScoreController>();
         GameOverText=GameObject.Find("GameOverText");
         GameOverText.SetActive(false);
    }
    private void Start()
    {
       ESAudioManager.Instance.PlaySoundEffect(ESAudioManager.SoundEffect.Start);
       //PlayerLivesText.text = _lives.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameOver)
            return;

        if (_lastVerticalAxis != Input.GetAxis("Vertical"))
        {
            _lastVerticalAxis = Input.GetAxis("Vertical");
            _animator.SetFloat("VerticalAxis", _lastVerticalAxis );
        }
            
        _deltaPos = MovementSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        gameObject.transform.Translate(_deltaPos);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                    Mathf.Clamp(gameObject.transform.position.y, Y_MIN_LIMIT, Y_MAX_LIMIT),
                                                    gameObject.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        
           
                
                //PlayerLivesText.text = _lives.ToString();
               // ESAudioManager.Instance.PlaySoundEffect(ESAudioManager.SoundEffect.Explode);
                if (_lives<=0)
                {
                    //Game Over
                    IsGameOver=true;
                    GameOverText.SetActive(true);
                   // ESAudioManager.Instance.PlaySoundEffect(ESAudioManager.SoundEffect.GameOver);
                   // _webClient.SaveScore();

                }
        
        
        //ESAudioManager.Instance.PlaySoundEffect(ESAudioManager.SoundEffect.Capture);
        Destroy(other.gameObject);
    }
}
