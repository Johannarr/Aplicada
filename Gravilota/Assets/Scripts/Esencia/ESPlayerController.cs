using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESPlayerController : MonoBehaviour
{
    const float Y_MIN_LIMIT = -4.2f;
    const float Y_MAX_LIMIT = 4.2f;

    [SerializeField]
    Vector3 MovementSpeed = new Vector3(0,10f), _deltaPos;
     ScoreController _scoreController; 
   
    // Start is called before the first frame update
    void Start()
    {
        _scoreController = GameObject.Find("GlobalScriptsText").GetComponent<ScoreController>();
        
    }

    // Update is called once per frame
    void Update()
    {
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
        }
        Destroy(other.gameObject);
    }
}
