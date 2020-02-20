using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESPlayerController : MonoBehaviour
{
    public TextMesh PlayerLivesText;
    public GameObject GameOverText;
    public bool IsGameOver;
    const float Y_MIN_LIMIT = -4.2f;
    const float Y_MAX_LIMIT = 4.2f;

    [SerializeField]
    Vector3 MovementSpeed = new Vector3(0,10f), _deltaPos;
    ScoreController _scoreController; 
    int _lives = 3;

   
    // Start is called before the first frame update
    private void Awake()
    {
         _scoreController = GameObject.Find("GlobalScriptsText").GetComponent<ScoreController>();
         GameOverText=GameObject.Find("GameOverText");
         GameOverText.SetActive(false);
    }
    private void Start()
    {
       PlayerLivesText.text = _lives.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameOver)
            return;
            
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
                _scoreController.IncrementScore(EssenceType.Blue);
                break;

            case "Red":
                _scoreController.IncrementScore(EssenceType.Red);
                break;
            case "Green":
                _scoreController.IncrementScore(EssenceType.Green);
                break;
            case "Pink":
                _scoreController.IncrementScore(EssenceType.Pink);
                break;
            case "Purple":
                _scoreController.IncrementScore(EssenceType.Purple);
                break;
            case "Yellow":
                _scoreController.IncrementScore(EssenceType.Yellow);
                break;
            case "Enemy":
                _lives--;
                PlayerLivesText.text = _lives.ToString();
                if (_lives<=0)
                {
                    //Game Over
                    IsGameOver=true;
                    GameOverText.SetActive(true);
                }
                break;
        
        }
        Destroy(other.gameObject);
    }
}
