using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocoPlayerController : MonoBehaviour
{
    public TextMesh PlayerLivesText;
    public GameObject GameOverText;
    public bool IsGameOver;
    const float Y_MIN_LIMIT = -4.2f;
    const float Y_MAX_LIMIT = 4.2f;

    [SerializeField]
    Vector3 MovementSpeed = new Vector3(0,10f), _deltaPos;
    CrocoScoreController _scoreController; 
    int _lives = 3;
    Animator _animator;
    float _lastVerticalAxis;
    CrocoWebClient _webClient;

   
    // Start is called before the first frame update
    private void Awake()
    {
        _webClient = GameObject.Find("GlobalScriptsText").GetComponent<CrocoWebClient>();
         _animator = GetComponent<Animator>();
         _scoreController = GameObject.Find("GlobalScriptsText").GetComponent<CrocoScoreController>();
         GameOverText=GameObject.Find("GameOverText");
         GameOverText.SetActive(false);
    }
    private void Start()
    {
       CrocoAudioManager.Instance.PlaySoundEffect(CrocoAudioManager.SoundEffect.Start);
       PlayerLivesText.text = _lives.ToString();
        
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
        switch (other.gameObject.tag)
        {
            case "Blue":
                _scoreController.IncrementScore(FishType.Blue);
                break;

            case "Red":
                _scoreController.IncrementScore(FishType.Red);
                break;
            case "Green":
                _scoreController.IncrementScore(FishType.Green);
                break;
            case "Orange":
                _scoreController.IncrementScore(FishType.Orange);
                break;
            case "Frog":
                _scoreController.IncrementScore(FishType.Frog);
                break;
            case "Enemy":
                _lives--;
                PlayerLivesText.text = _lives.ToString();
                CrocoAudioManager.Instance.PlaySoundEffect(CrocoAudioManager.SoundEffect.BadCapure);
                if (_lives<=0)
                {
                    //Game Over
                    IsGameOver=true;
                    GameOverText.SetActive(true);
                    CrocoAudioManager.Instance.PlaySoundEffect(CrocoAudioManager.SoundEffect.GameOver);
                    _webClient.SaveScore();

                }
                break;
        
        }
        CrocoAudioManager.Instance.PlaySoundEffect(CrocoAudioManager.SoundEffect.Capture);
        Destroy(other.gameObject);
    }
}
